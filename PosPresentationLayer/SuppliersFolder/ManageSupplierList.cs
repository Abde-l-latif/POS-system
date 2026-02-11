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

namespace PosPresentationLayer.SuppliersFolder
{
    public partial class ManageSupplierList : Form
    {

        DataTable DT = new DataTable();

        string DbColumn = String.Empty;
        public ManageSupplierList()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DT = clsSupplier.GetAllSuppliers();
            _InitializeDataGrid();
            comboBox1.SelectedIndex = 0 ;
            comboBox2.Visible = false;
            comboBox2.Enabled = false;
        }

        private void _InitializeDataGrid()
        {
            dataGridView1.DataSource = DT;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns["SupplierID"].HeaderText = "Supplier ID";
            dataGridView1.Columns["PersonID"].HeaderText = "Person ID";
            dataGridView1.Columns["FirstName"].HeaderText = "First Name";
            dataGridView1.Columns["IsActive"].HeaderText = "Active";
            dataGridView1.Columns["LastName"].HeaderText = "Last Name";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Created At";
            dataGridView1.Columns["UpdatedAt"].HeaderText = "Updated At";

            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void _ReloadDataGrid()
        {
            DT = clsSupplier.GetAllSuppliers();
            dataGridView1.DataSource = DT;
            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void updateSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0) 
            {
                AddUpdateSupplierForm fm = new AddUpdateSupplierForm(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)); 
                fm.ShowDialog();

                _ReloadDataGrid();
            }
            else
                MessageBox.Show("Please Select first a row", "Unselected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUpdateSupplierForm fm = new AddUpdateSupplierForm();
            fm.ShowDialog();

            _ReloadDataGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textFilter.KeyPress -= textFilter_KeyPress;
            comboBox2.Visible = false;
            comboBox2.Enabled = false;
            textFilter.Text = "";
            textFilter.Visible = true;
            textFilter.Enabled = true;

            if (comboBox1.Text == "none")
            {
                DT.DefaultView.RowFilter = "";
                LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
                textFilter.Enabled = false;
                textFilter.Text = ""; 
                return ;
            }

            if(comboBox1.Text == "Is Active")
            {
                comboBox2.Visible = true;
                comboBox2.Enabled = true;
                textFilter.Text = "";
                textFilter.Enabled = false;
                textFilter.Visible = false;
                DbColumn = "IsActive";
                comboBox2.SelectedIndex = 0 ;
                return ;
            }

            switch(comboBox1.Text)
            {
                case "Supplier ID":
                    {
                        DbColumn = "SupplierID";
                        textFilter.KeyPress += textFilter_KeyPress;
                        break; 
                    }
                case "Person ID":
                    {
                        DbColumn = "PersonID";
                        textFilter.KeyPress += textFilter_KeyPress;
                        break;
                    }
                case "First Name":
                    {
                        DbColumn = "FirstName";
                        break;
                    }
                case "Last Name":
                    {
                        DbColumn = "LastName";
                        break;
                    }
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

            if(DbColumn != "PersonID" && DbColumn != "SupplierID")
            {
                DT.DefaultView.RowFilter = String.Format("[{0}] LIKE '{1}%'", DbColumn, textFilter.Text);
            }
            else
            {
                DT.DefaultView.RowFilter = String.Format("CONVERT([{0}], 'System.String') LIKE '{1}%'", DbColumn, textFilter.Text);
            }

            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Yes")
                DT.DefaultView.RowFilter = String.Format("[{0}] = {1}" , DbColumn , 1);
            else
                DT.DefaultView.RowFilter = String.Format("[{0}] = {1}", DbColumn, 0);

            LBrecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

        }
    }
}
