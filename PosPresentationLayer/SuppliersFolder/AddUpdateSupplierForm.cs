using PosBusinessLayer;
using PosPresentationLayer.Properties;
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

namespace PosPresentationLayer.SuppliersFolder
{
    public partial class AddUpdateSupplierForm : Form
    {
        public event EventHandler<int> SupplierIdSelected; 
        clsSupplier supplier = new clsSupplier();
        enum enMode { AddMode , UpdateMode }

        enMode _Mode = enMode.AddMode;
        
        public AddUpdateSupplierForm()
        {
            InitializeComponent();
            _Mode = enMode.AddMode;
            StartPosition = FormStartPosition.CenterScreen;
            personDetailsWithFilter1.PersonSelected += _GetPersonID;
            BtnSave.Enabled = false;
        }

        public AddUpdateSupplierForm(int SupplierID)
        {
            InitializeComponent();
            _Mode = enMode.UpdateMode;
            StartPosition = FormStartPosition.CenterScreen;
            supplier = clsSupplier.FindSupplierByID(SupplierID);
        }

        private void _GetPersonID(object sender , int PersonID)
        {
            supplier.SetPersonID(PersonID);
            LBpersonID.Text = PersonID.ToString();
            personDetailsWithFilter1.personDetails.EnableUpdate = false;
            BtnSave.Enabled = true;
        }

        private void AddUpdateSupplierForm_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.UpdateMode)
            {

                pictureTitle.Image = Resources.SupplierEdit;
                LbTitle.Text = "Update Supplier";

                personDetailsWithFilter1.TextField = supplier.PersonID.ToString();
                personDetailsWithFilter1.FilterField = false;

                personDetailsWithFilter1.PersonID = supplier.PersonID;
                personDetailsWithFilter1.personDetails.EnableUpdate = true;

                LbSupplierID.Text = supplier.SupplierID.ToString();
                LBpersonID.Text = supplier.PersonID.ToString();
                checkBox1.Checked = supplier.IsActive;


                BtnSave.Enabled = true;
            }
            else
            {
                pictureTitle.Image = Resources.suppliersAdd;
                LbTitle.Text = "Add New Supplier";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {   
            supplier.IsActive = checkBox1.Checked;

            if (supplier.isPersonAlreadySupplier())
            {
                MessageBox.Show("This Person is Already a supplier !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                personDetailsWithFilter1.FilterField = true;
                return;
            }

            if(supplier.Save())
            {
                MessageBox.Show("Operation Done successfully !", "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LbSupplierID.Text = supplier.SupplierID.ToString();
                SupplierIdSelected?.Invoke(this, supplier.SupplierID);
                BtnSave.Enabled = false;
                personDetailsWithFilter1.personDetails.EnableUpdate = false; 
            }
            else
                MessageBox.Show("Operation Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
