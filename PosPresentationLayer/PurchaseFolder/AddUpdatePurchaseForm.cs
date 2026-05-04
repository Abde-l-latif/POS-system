using PosBusinessLayer;
using PosPresentationLayer.PurchaseItemFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.PurchaseFolder
{
    public partial class AddUpdatePurchaseForm : Form
    {
        enum enMode { AddMode, UpdateMode };

        enMode _Mode = enMode.AddMode;

        clsPurchases Purchase; 
        public AddUpdatePurchaseForm()
        {
            _Mode = enMode.AddMode;
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

        public AddUpdatePurchaseForm(int PurchaseID)
        {
            _Mode = enMode.UpdateMode;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _InitializeComboBoxes();
            _InitializeDataGridView();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);
            textQuantity.KeyPress += KeyPress_ValidateNumeric;
            textPrice.KeyPress += KeyPress_ValidateNumericWithComma;
            Purchase = clsPurchases.getPurchaseById(PurchaseID);
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
                    clsPurchaseItems existingItem = clsPurchaseItems.GetPurchaseItemsByProductIDandPurchaseID(purchaseID, Convert.ToInt32(dataGridView1.Rows[i].Cells["ProductID"].Value));

                    if (existingItem != null)
                    {
                        clsProducts product = clsProducts.GetProductByID(existingItem.ProductID);

                        if (product != null)
                        {
                            product.StockQuantity -= existingItem.Quantity;
                        }

                        existingItem.ProductID = Convert.ToInt32(dataGridView1.Rows[i].Cells["ProductID"].Value);
                        existingItem.Quantity = Convert.ToInt32(dataGridView1.Rows[i].Cells["ProductQuantity"].Value);
                        existingItem.UnitBuyingPrice = Convert.ToDecimal(dataGridView1.Rows[i].Cells["ProductUnitPrice"].Value);

                        if (existingItem.Save())
                        {
                            if (product != null)
                            {
                                product.StockQuantity += existingItem.Quantity;
                                product.Save();
                            }
                        }
                        else
                            MessageBox.Show("An error occurred while saving the purchase Item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
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
                }

                MessageBox.Show("Purchase saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnSave.Enabled = false;
            }
            else
                MessageBox.Show("An error occurred while saving the purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddUpdatePurchaseForm_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.UpdateMode)
            {
                dateTimePicker1.Value = Purchase.PurchaseDate;
                comboSupplier.SelectedValue = Purchase.SupplierID;
                textInvoiceNo.Text = Purchase.SupplierInvoiceNo;
                LbTitle.Text = "Update Purchase";

                DataTable dt = clsPurchaseItems.PurchaseItemsByPurchaseID(Purchase.PurchaseID);

                if(dt.Rows.Count > 0)
                {
                    decimal total = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row["ProductID"], row["ProductName"], row["Quantity"], row["UnitBuyingPrice"]);
                        total += ((decimal)row["UnitBuyingPrice"] * (int)row["Quantity"]);
                    }
                   
                    LbTotal.Text = total.ToString("0.00") + " DH";
                }

            }
            else
            {
                LbTitle.Text = "Add New Purchase";
            }
        }

        private void updateItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                UpdatePurchaseItem updateForm = new UpdatePurchaseItem();

                updateForm.UpdatedQuantity += (Obj, newQuantity) =>
                {
                    dataGridView1.SelectedRows[0].Cells["ProductQuantity"].Value = newQuantity;
                };

                updateForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Please select a row to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
