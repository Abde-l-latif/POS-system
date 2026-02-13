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

namespace PosPresentationLayer.SuppliersFolder.Controls
{
    public partial class SupplierDetails : UserControl
    {
        public SupplierDetails()
        {
            InitializeComponent();
        }

        public void LoadBySupplierID(int ID)
        {
            if(clsSupplier.isSupplierExist(ID))
            {
                clsSupplier Supplier = clsSupplier.FindSupplierByID(ID);

                personDetails1.FillByPersonID(Supplier.PersonID);

                personDetails1.EnableUpdate = false;

                LBsupplierID.Text = Supplier.SupplierID.ToString();

                LbActive.Text = Supplier.IsActive ? "Yes" : "No";

                LbUpdated.Text = Supplier.UpdatedAt.ToShortDateString();

                LBcreatedAt.Text = Supplier.CreatedAt.ToShortDateString();


            }
            else
                MessageBox.Show("Supplier Not Found !", "Not Found" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
