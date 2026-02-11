using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PosPresentationLayer.UsersFolder
{
    public partial class ManageUsersForm : Form
    {
        string FilterWith = "none";

        DataTable Dt = new DataTable();
        public ManageUsersForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Dt = clsUsers.GetAllUsers();
            _InitializeDataGrid();
            comboBox1.SelectedIndex = 0; 
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
        }

        private void _InitializeDataGrid()
        {
            dataGridView1.DataSource = Dt;

            dataGridView1.Columns["UserID"].HeaderText = "User ID";
            dataGridView1.Columns["FirstName"].HeaderText = "First Name";
            dataGridView1.Columns["LastName"].HeaderText = "Last Name";
            dataGridView1.Columns["IsActive"].HeaderText = "Active";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Created At";
    

            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUser fm = new AddUser();
            fm.ShowDialog();
            dataGridView1.DataSource = Dt;
            LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textFilter.Visible = true;
            textFilter.Enabled = true;
            comboBox2.Enabled = false;
            comboBox2.Visible = false;
            textFilter.KeyPress -= textFilter_KeyPress;

            if (comboBox1.Text == "none")
            {
                FilterWith = "none";
                textFilter.Text = "";
                textFilter.Enabled = false;
                Dt.DefaultView.RowFilter = "";
                LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
                return;
            }
           

            switch(comboBox1.Text)
            {
                case "User ID":
                    FilterWith = "UserID";
                    textFilter.KeyPress += textFilter_KeyPress;
                    break;
                case "First Name":
                    FilterWith = "FirstName";
                    break;
                case "Last Name":
                    FilterWith = "LastName";
                    break;
                case "Username":
                    FilterWith = "Username";
                    break;
                case "Is Active":
                    FilterWith = "IsActive";
                    comboBox2.SelectedIndex = 0;
                    comboBox2.Enabled = true;
                    comboBox2.Visible = true;
                    textFilter.Visible = false;
                    break;
                default:
                    FilterWith = "none";
                    break;

            }
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if (textFilter.Text == "")
            {
                Dt.DefaultView.RowFilter = "";
                LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
                return;
            }


            if (FilterWith != "UserID" && FilterWith != "IsActive")
            {
                Dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterWith, textFilter.Text);
            }
            else if (FilterWith == "UserID")
            {
                Dt.DefaultView.RowFilter = string.Format("CONVERT([{0}], 'System.String') Like '{1}%'", FilterWith, textFilter.Text);
            }

            LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";

          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Yes")
            {
                Dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterWith, 1);
            }
            else
            {
                Dt.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterWith, 0);
            }

            LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";


        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
