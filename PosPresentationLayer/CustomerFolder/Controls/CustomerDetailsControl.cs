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

namespace PosPresentationLayer.CustomerFolder.Controls
{
    public partial class CustomerDetailsControl : UserControl
    {
        public CustomerDetailsControl()
        {
            InitializeComponent();
        }

        public void LoadByCustomerID(int ID)
        {
            if (clsCustomers.isCustomerExist(ID))
            {
                clsCustomers Customer = clsCustomers.FindCustomerByID(ID);

                personDetails1.FillByPersonID(Customer.PersonID);

                personDetails1.EnableUpdate = false;

                LBcustomerID.Text = Customer.CustomerID.ToString();

                LbActive.Text = Customer.IsActive ? "Yes" : "No";

                LbUpdated.Text = Customer.UpdatedAt.ToShortDateString();

                LBcreatedAt.Text = Customer.CreatedAt.ToShortDateString();


            }
            else
                MessageBox.Show("Supplier Not Found !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
