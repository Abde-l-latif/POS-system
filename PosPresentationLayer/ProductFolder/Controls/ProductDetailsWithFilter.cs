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

namespace PosPresentationLayer.ProductFolder.Controls
{
    public partial class ProductDetailsWithFilter : UserControl
    {
        int ProductID = -1;

        string FilterText = ""; 
        public ProductDetailsWithFilter()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0 ;
        }

        private bool _Filter = true;  
        public bool FilterSection
        {
            get
            {
                return _Filter;
            }
            set
            {
                _Filter = value;
                groupBox2.Enabled = _Filter;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch(comboBox1.Text)
           {
                case "Product ID":
                    {
                        FilterText = "ProductID";
                        break;
                    }
                case "BarCode":
                    {
                        FilterText = "BarCode";
                        break;
                    }
                case "Product Name":
                    {
                        FilterText = "ProductName";
                        break;
                    }
           }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if(FilterText == "ProductID")
            {
                productDetails1.LoadByProductId(Convert.ToInt32(TextBoxFilter.Text));
                groupBox2.Enabled = false;
                return; 
            }

            if(!String.IsNullOrEmpty(TextBoxFilter.Text))
            {
                ProductID = clsProducts.GetIdOfFilteredProduct(FilterText, TextBoxFilter.Text); 
                productDetails1.LoadByProductId(ProductID);
                groupBox2.Enabled = false;
            }
            else
            {
                MessageBox.Show("text field is empty" , "empty" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddUpdateProductsForm fm = new AddUpdateProductsForm();
            fm.GetProductID += LoadAddedProduct;
            fm.ShowDialog();
        }

        private void LoadAddedProduct(object sender , int id)
        {
            productDetails1.LoadByProductId(id);
            TextBoxFilter.Text = id.ToString();
            comboBox1.SelectedIndex = 0;
            groupBox2.Enabled = false;
        }
    }
}
