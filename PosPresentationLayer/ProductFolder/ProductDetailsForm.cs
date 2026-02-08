using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.ProductFolder
{
    public partial class ProductDetailsForm : Form
    {
        public ProductDetailsForm(int ProductID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            productDetails1.LoadByProductId(ProductID);
        }


    }
}
