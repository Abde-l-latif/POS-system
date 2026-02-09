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

namespace PosPresentationLayer.PeopleFolder
{
    public partial class ManagePeople : Form
    {
        string FilterWith = "none";

        DataTable Dt = new DataTable();
        public ManagePeople()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Dt = clsPeople.GetPeopleList();
            _InitializeDataGrid();
            comboBox1.SelectedIndex = 0;
        }

        private void _InitializeDataGrid()
        {
            dataGridView1.DataSource = Dt;

            dataGridView1.Columns["PersonID"].HeaderText = "Person ID";
            dataGridView1.Columns["FirstName"].HeaderText = "First Name";
            dataGridView1.Columns["LastName"].HeaderText = "Last Name";
            dataGridView1.Columns["BirthDate"].HeaderText = "Birth Date";
            dataGridView1.Columns["PersonAddress"].HeaderText = "Person Address";
            dataGridView1.Columns["PersonImage"].HeaderText = "Person Image";
            dataGridView1.Columns["PhoneNumber"].HeaderText = "Phone Number";

            dataGridView1.Columns["PersonImage"].Width = 295;

            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records"; 

        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0 )
            {
                PersonDetailsForm fm = new PersonDetailsForm((int)dataGridView1.SelectedCells[0].Value);
                fm.ShowDialog(); 
            }
            else
                MessageBox.Show("Please Select first a row", "Unselected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void editPersonInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                AddUpdatePersonScreen fm = new AddUpdatePersonScreen((int)dataGridView1.SelectedCells[0].Value);
                fm.ShowDialog();

                Dt = clsPeople.GetPeopleList();
                dataGridView1.DataSource = Dt;
                LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
            }
            else
                MessageBox.Show("Please Select first a row", "Unselected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textFilter.KeyPress -= textFilter_KeyPress;
            textFilter.Enabled = true;

            switch (comboBox1.Text.ToString())
            {
                case "Person ID":
                    {
                        FilterWith = "PersonID";
                        textFilter.KeyPress += textFilter_KeyPress;
                        break;
                    }
                case "First Name":
                    { 
                        FilterWith = "FirstName";
                        break;
                    }
                case "Gender":
                    {
                        FilterWith = "Gender";
                        break;
                    }
                default:
                    {
                        FilterWith = "none";
                        textFilter.Enabled = false;
                        textFilter.Text = "";
                        Dt.DefaultView.RowFilter = "";
                        LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
                        break;
                    }
            }
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if (textFilter.Text == "")
                return;

            if(FilterWith != "PersonID")
            {
                Dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'" , FilterWith, textFilter.Text);
            }
            else
            {
                Dt.DefaultView.RowFilter = string.Format("CONVERT([{0}], 'System.String') Like '{1}%'", FilterWith, textFilter.Text);
            }

            LBrecords.Text = dataGridView1.Rows.Count.ToString() + " Records";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUpdatePersonScreen Fm = new AddUpdatePersonScreen();
            Fm.ShowDialog();

            Dt = clsPeople.GetPeopleList();
            dataGridView1.DataSource = Dt;
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
