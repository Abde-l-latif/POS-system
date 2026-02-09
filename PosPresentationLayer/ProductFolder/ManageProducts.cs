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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PosPresentationLayer.ProductFolder
{

    public partial class ManageProducts : Form
    {
        string FilterText = "";
        DataTable DT = new DataTable();
        public ManageProducts()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DT = clsProducts.GetAllProducts();
            _InitializeDataGrid();
            comboBox1.SelectedIndex = 0;
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
        }

        private void _InitializeDataGrid()
        {
            dataGridView1.DataSource = DT;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["ProductID"].HeaderText = "ID";
            dataGridView1.Columns["ProductName"].HeaderText = "Product Name";
            dataGridView1.Columns["SellingPrice"].HeaderText = "Selling Price";
            dataGridView1.Columns["IsActive"].HeaderText = "Active";
            dataGridView1.Columns["CategoryName"].HeaderText = "Category";
            dataGridView1.Columns["CreatedByUserID"].HeaderText = "Created By User ID";
            dataGridView1.Columns["ProductImage"].HeaderText = "Product Image";

            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void _ReloadDataGrid()
        {
            DT = clsProducts.GetAllProducts();
            dataGridView1.DataSource = DT;
            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUpdateProductsForm fm = new AddUpdateProductsForm();
            fm.ShowDialog();

            _ReloadDataGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Is Active")
            {
                FilterText = "IsActive"; 
                comboBox2.SelectedIndex = 0;
                comboBox2.Enabled = true;
                comboBox2.Visible = true;
                textFilter.Text = "";
                textFilter.Visible = false;
                return;
            }

            if (comboBox1.Text == "none")
            {
                textFilter.Visible = false;
                textFilter.Text = "";
                DT.DefaultView.RowFilter = "";
                LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
                return;
            }

            textFilter.KeyPress -= textFilter_KeyPress;
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
            textFilter.Visible = true;

            switch (comboBox1.Text)
            {
                case "Product ID":
                    {
                        FilterText = "ProductID";
                        textFilter.KeyPress += textFilter_KeyPress;
                        break; 
                    }
                case "User ID":
                    {
                        FilterText = "CreatedByUserID";
                        textFilter.KeyPress += textFilter_KeyPress;
                        break;
                    }
                case "Product name":
                    {
                        FilterText = "ProductName";
                        break;
                    }
                case "BarCode":
                    {
                        FilterText = "BarCode";
                        break;
                    }
                case "Category name":
                    {
                        FilterText = "CategoryName";
                        break;
                    }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Yes")
            {
                DT.DefaultView.RowFilter = String.Format("[{0}] = {1}" , FilterText , 1);
                LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
            }
            else
            {
                DT.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterText, 0);
                LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
            }
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if(textFilter.Text == "")
            {
                DT.DefaultView.RowFilter = "";
                LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
                return;
            }

            if(FilterText != "ProductID" && FilterText != "CreatedByUserID")
                DT.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'", FilterText, textFilter.Text);
          
            else
                DT.DefaultView.RowFilter = String.Format("CONVERT([{0}], 'System.String') LIKE '{1}%'", FilterText, textFilter.Text);
            
            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
   
        }

        private void updateProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int ProductID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                AddUpdateProductsForm fm = new AddUpdateProductsForm(ProductID);
                fm.ShowDialog();

                _ReloadDataGrid();
            }
            else
                MessageBox.Show("Please Select first a row", "Unselected" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void productDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ProductID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                ProductDetailsForm fm = new ProductDetailsForm(ProductID);
                fm.ShowDialog();

            }
            else
                MessageBox.Show("Please Select first a row", "Unselected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
