using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.ProductFolder.Controls
{
    public partial class ProductDetails : UserControl
    {
        public ProductDetails()
        {
            InitializeComponent();
            linkLabel1.Enabled = false;
        }

        private string _ImagePath;

        public void LoadByProductId(int productID)
        {
            clsProducts Product = clsProducts.GetProductByID(productID);

            if(Product != null)
            {
                LbCategory.Text = clsCategories.GetCategoryByID(Product.CategoryID).CategoryName;
                LbActive.Text = Product.IsActive ? "Yes" : "No";
                LbBarCode.Text = Product.BarCode; 
                LbBuyingPrice.Text = Product.BuyingPrice.ToString();
                LbSellingPrice.Text = Product.SellingPrice.ToString();
                LbQuantity.Text = Product.StockQuantity.ToString();
                LbName.Text = Product.ProductName;
                LbCreatedAt.Text = Product.CreatedAt.ToShortDateString();
                LbUpdatedAt.Text = Product.UpdatedAt.ToShortDateString();
                LbVat.Text = Product.TaxRate.ToString();
                linkLabel1.Enabled = true;

                if (!String.IsNullOrEmpty(Product.ProductImage))
                {
                    using (var img = Image.FromFile(Product.ProductImage))
                    {
                        pictureBox1.Image = new Bitmap(img);
                    }

                    _ImagePath = Product.ProductImage; 
                }

                
            }
            else
                MessageBox.Show("Product Not Found" , "Not Found" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                MessageBox.Show($"Image Path is : {_ImagePath}", "Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("This Product Doesn't have an image", "Doesn't Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
