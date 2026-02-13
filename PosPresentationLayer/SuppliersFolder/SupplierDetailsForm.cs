using Microsoft.Win32;
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
    public partial class SupplierDetailsForm : Form
    {
        public SupplierDetailsForm(int SupplierID)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            supplierDetails1.LoadBySupplierID(SupplierID);
        }
    }
}
