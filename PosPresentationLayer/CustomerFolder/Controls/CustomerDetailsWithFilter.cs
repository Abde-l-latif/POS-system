using PosBusinessLayer;
using PosPresentationLayer.SuppliersFolder.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.CustomerFolder.Controls
{
    public partial class CustomerDetailsWithFilter : UserControl
    {
        public CustomerDetailsWithFilter()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            AddUpdateCustomersForm fm = new AddUpdateCustomersForm();
            fm.CustomerIdSelected += _CustomerIdReceived;
            fm.ShowDialog();
        }

        private void _CustomerIdReceived(object sender, int ID)
        {
            customerDetailsControl1.LoadByCustomerID(ID);
            comboBox1.SelectedIndex = 0;
            TextBoxFilter.Text = ID.ToString();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxFilter.Text))
            {
                MessageBox.Show("Field Is Empty Lack of Information", "Lack Of Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox1.Text == "Customer ID")
            {
                int CustomerID = Convert.ToInt32(TextBoxFilter.Text);

                if (clsCustomers.isCustomerExist(CustomerID))
                {
                    customerDetailsControl1.LoadByCustomerID(CustomerID);
                }
                else
                    MessageBox.Show("Customer Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "First Name")
            {
                int ID = clsCustomers.GetCustomerIDByFirstName(TextBoxFilter.Text);

                if (ID != -1)
                {
                    customerDetailsControl1.LoadByCustomerID(ID);
                }
                else
                    MessageBox.Show("Supplier Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxFilter.KeyPress -= textFilter_KeyPress;

            if (comboBox1.Text == "Customer ID")
            {
                TextBoxFilter.KeyPress += textFilter_KeyPress;
            }
        }
    }
}
