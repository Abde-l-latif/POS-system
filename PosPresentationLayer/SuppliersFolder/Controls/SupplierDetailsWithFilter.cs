using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.SuppliersFolder.Controls
{
    public partial class SupplierDetailsWithFilter : UserControl
    {

        public SupplierDetailsWithFilter()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void BtnAddSupplier_Click(object sender, EventArgs e)
        {
            AddUpdateSupplierForm fm = new AddUpdateSupplierForm();
            fm.SupplierIdSelected += _SupplierIdReceived;
            fm.ShowDialog();

        }

        private void _SupplierIdReceived(object sender, int ID)
        {
            supplierDetails1.LoadBySupplierID(ID);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxFilter.Text))
            {
                MessageBox.Show("Field Is Empty Lack of Information", "Lack Of Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox1.Text == "Supplier ID")
            {
                int SupplierID = Convert.ToInt32(TextBoxFilter.Text);

                if (clsSupplier.isSupplierExist(SupplierID))
                {
                    supplierDetails1.LoadBySupplierID(SupplierID);
                }
                else
                    MessageBox.Show("Supplier Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "First Name")
            {
                int ID = clsSupplier.GetSupplierIDByFirstName(TextBoxFilter.Text);

                if (ID != -1)
                {
                    supplierDetails1.LoadBySupplierID(ID);
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

            if (comboBox1.Text == "Supplier ID")
            {
                TextBoxFilter.KeyPress += textFilter_KeyPress;
            }
        }
    }
}
