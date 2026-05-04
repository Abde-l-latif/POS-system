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
    public partial class ManagePurchases : Form
    {
        string FilterText = "";
        DataTable DT = new DataTable();
        public ManagePurchases()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DT = clsPurchases.GetAllPurchases();
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
            dataGridView1.Columns["PurchaseID"].HeaderText = "ID";
            dataGridView1.Columns["PurchaseDate"].HeaderText = "Purchase Date";
            dataGridView1.Columns["CreatedByUserID"].HeaderText = "Created By User ID";
            dataGridView1.Columns["SupplierID"].HeaderText = "Supplier ID";
            dataGridView1.Columns["IsDeleted"].HeaderText = "Deleted";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Created At";
            dataGridView1.Columns["UpdatedAt"].HeaderText = "Updated At";
            dataGridView1.Columns["InternalInvoiceNo"].HeaderText = "Invoice No";
            dataGridView1.Columns["SupplierInvoiceNo"].HeaderText = "Supplier Invoice No";

            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void _ReloadDataGrid()
        {
            DT = clsPurchases.GetAllPurchases();
            dataGridView1.DataSource = DT;
            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddUpdatePurchaseForm AddForm = new AddUpdatePurchaseForm();
            AddForm.ShowDialog();
            _ReloadDataGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textFilter.KeyPress -= textFilter_KeyPress;
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
            textFilter.Visible = true;
            textFilter.Enabled = true;

            if (comboBox1.Text == "Is Deleted")
            {
                FilterText = "IsDeleted";
                comboBox2.SelectedIndex = 0;
                comboBox2.Enabled = true;
                comboBox2.Visible = true;
                textFilter.Text = "";
                textFilter.Visible = false;
                return;
            }

            if (comboBox1.Text == "none")
            {
                textFilter.Enabled = false;
                textFilter.Text = "";
                DT.DefaultView.RowFilter = "";
                LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
                return;
            }


            switch (comboBox1.Text)
            {
                case "Purchase ID":
                    {
                        FilterText = "PurchaseID";
                        textFilter.KeyPress += textFilter_KeyPress;
                        break;
                    }
                case "User ID":
                    {
                        FilterText = "CreatedByUserID";
                        textFilter.KeyPress += textFilter_KeyPress;
                        break;
                    }
                case "System Invoice No":
                    {
                        FilterText = "InternalInvoiceNo";
                        break;
                    }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Yes")
            {
                DT.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterText, 1);
            }
            else
            {
                DT.DefaultView.RowFilter = String.Format("[{0}] = {1}", FilterText, 0);
            }
            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if (textFilter.Text == "")
            {
                DT.DefaultView.RowFilter = "";
                LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
                return;
            }

            if (FilterText != "PurchaseID" && FilterText != "CreatedByUserID")
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

        private void updatePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a purchase to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int purchaseID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PurchaseID"].Value);

            AddUpdatePurchaseForm UpdateForm = new AddUpdatePurchaseForm(purchaseID);

            UpdateForm.ShowDialog();

            _ReloadDataGrid();

        }
    }
}
