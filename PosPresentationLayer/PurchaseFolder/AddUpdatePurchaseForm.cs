using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.PurchaseFolder
{
    public partial class AddUpdatePurchaseForm : Form
    {

        clsPurchases Purchase; 
        public AddUpdatePurchaseForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Purchase = new clsPurchases();
            _InitializeComboBoxes();
            _InitializeDataGridView();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);
            textQuantity.KeyPress += KeyPress_ValidateNumeric;
            textPrice.KeyPress += KeyPress_ValidateNumericWithComma;

        }

        private void _InitializeComboBoxes()
        {
            comboSupplier.DataSource = clsSupplier.GetAllSuppliers();
            comboSupplier.DisplayMember = "FullName";
            comboSupplier.ValueMember = "SupplierID";

            comboProduct.DataSource = clsProducts.GetAllProducts();
            comboProduct.DisplayMember = "ProductName";
            comboProduct.ValueMember = "ProductID"; 
        }

        private void _InitializeDataGridView()
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void text_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, "This field is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
                e.Cancel = false;
            }
        }

        private void KeyPress_ValidateNumeric(object sender, KeyPressEventArgs e)
        {
    
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void KeyPress_ValidateNumericWithComma(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView1.Rows.Add(comboProduct.SelectedValue, comboProduct.Text, textQuantity.Text, textPrice.Text);
            comboProduct.SelectedIndex = 0;

            if(dataGridView1.Rows.Count > 0)
            {
                decimal total = 0; 

                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    decimal price = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ProductUnitPrice"].Value);
                    int quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells["ProductQuantity"].Value);
                    total += price * quantity;
                }

                LbTotal.Text = total.ToString("0.00") + " DH";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Purchase.PurchaseDate = dateTimePicker1.Value;
            Purchase.CreatedByUserID = clsGlobal.User.UserID;
            Purchase.SupplierID = Convert.ToInt32(comboSupplier.SelectedValue);
            Purchase.IsDeleted = false;
            Purchase.SupplierInvoiceNo = textInvoiceNo.Text;

            if(Purchase.Save())
            {
                int purchaseID = Purchase.PurchaseID;

                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    clsPurchaseItems item = new clsPurchaseItems();
                    item.ProductID = Convert.ToInt32(dataGridView1.Rows[i].Cells["ProductID"].Value);
                    item.Quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells["ProductQuantity"].Value);
                    item.UnitBuyingPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ProductUnitPrice"].Value);
                    item.PurchaseID = purchaseID;
                    if (item.Save())
                    {
                        clsProducts product = clsProducts.GetProductByID(item.ProductID);
                        if (product != null)
                        {
                            product.StockQuantity += item.Quantity;
                            product.Save();
                        }
                    }
                    else
                        MessageBox.Show("An error occurred while saving the purchase Item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Purchase saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnSave.Enabled = false;
            }
            else
                MessageBox.Show("An error occurred while saving the purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
