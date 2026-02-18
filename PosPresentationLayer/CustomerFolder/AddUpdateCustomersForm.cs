using PosBusinessLayer;
using PosPresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.CustomerFolder
{
    public partial class AddUpdateCustomersForm : Form
    {

        public event EventHandler<int> CustomerIdSelected;

        clsCustomers customer = new clsCustomers();
        enum enMode { AddMode, UpdateMode }

        enMode _Mode = enMode.AddMode;

        public AddUpdateCustomersForm()
        {
            _Mode = enMode.AddMode; 
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            personDetailsWithFilter1.PersonSelected += _GetPersonID;
            BtnSave.Enabled = false;
        }

        public AddUpdateCustomersForm(int CustomerID)
        {
            _Mode = enMode.UpdateMode;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            customer = clsCustomers.FindCustomerByID(CustomerID);
        }

        private void _GetPersonID(object sender, int PersonID)
        {
            customer.SetPersonID(PersonID);
            LBpersonID.Text = PersonID.ToString();
            personDetailsWithFilter1.personDetails.EnableUpdate = false;
            BtnSave.Enabled = true;
        }

        private void AddUpdateCustomerForm_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.UpdateMode)
            {

                pictureTitle.Image = Resources.network_diagramUpdateTitle;
                LbTitle.Text = "Update Customer";

                personDetailsWithFilter1.TextField = customer.PersonID.ToString();

                personDetailsWithFilter1.PersonID = customer.PersonID;
                personDetailsWithFilter1.personDetails.EnableUpdate = true;

                LbCustomerID.Text = customer.CustomerID.ToString();
                LBpersonID.Text = customer.PersonID.ToString();
                checkBox1.Checked = customer.IsActive;


                BtnSave.Enabled = true;
            }
            else
            {
                pictureTitle.Image = Resources.network_diagramAddTitle;
                LbTitle.Text = "Add New Customer";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            customer.IsActive = checkBox1.Checked;

            if (_Mode == enMode.AddMode)
            {
                if (customer.isPersonAlreadyCustomer())
                {
                    MessageBox.Show("This Person is Already a customer !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    personDetailsWithFilter1.FilterField = true;
                    return;
                }

            }

            if (customer.Save())
            {
                MessageBox.Show("Operation Done successfully !", "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LbCustomerID.Text = customer.CustomerID.ToString();
                CustomerIdSelected?.Invoke(this, customer.CustomerID);
                BtnSave.Enabled = false;
                personDetailsWithFilter1.personDetails.EnableUpdate = false;
            }
            else
                MessageBox.Show("Operation Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
