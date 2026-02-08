using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.ProductFolder
{
    public partial class AddUpdateProductsForm : Form
    {
        public event EventHandler<int> GetProductID;
        enum enMode { addMode , UpdateMode}
        
        enMode _Mode;

        clsProducts Product ;  

        string _ImagePath = "";

        string _UpdateModeImagePath = ""; 

        bool _MarkDeleteImage = false;

        public AddUpdateProductsForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _InitializeCategories();
            _Mode = enMode.addMode;
            Product = new clsProducts();
        }

        public AddUpdateProductsForm(int productID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _InitializeCategories();
            _Mode = enMode.UpdateMode;
            Product = clsProducts.GetProductByID(productID);
            _InitializeUI();
        }

        private void _FillProductDataOnUI()
        {
            textProductName.Text = Product.ProductName;
            textBarCode.Text = Product.BarCode;
            textQuantity.Text = Product.StockQuantity.ToString("00");
            comboBox1.SelectedValue = Product.CategoryID;
            checkActive.Checked = Product.IsActive;
            textBuyingPrice.Text = Product.BuyingPrice.ToString("0.00");
            textSellingPrice.Text = Product.SellingPrice.ToString("0.00");
            textTax.Text = Product.TaxRate.ToString();

            if (!String.IsNullOrEmpty(Product.ProductImage))
            {
                using(var img = Image.FromFile(Product.ProductImage))
                {
                    pictureBox1.Image = new Bitmap(img);
                };

                _ImagePath = Product.ProductImage;

                _UpdateModeImagePath = Product.ProductImage;

                BtnBrowse.Enabled = false;
                
            }
        }

        private void _InitializeUI()
        {

            LbDefaultTax.Text = $"Default Tax is {clsSettings.GetSystemTax()} %"; 

            if (_Mode == enMode.addMode)
                LbTitle.Text = "New Product";
            else
            {
                LbTitle.Text = "Update Product";
                _FillProductDataOnUI();
            }
        }

        private void _InitializeCategories()
        {
            comboBox1.DataSource = clsCategories.GetAllCategories();
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
            comboBox1.SelectedIndex = 0;
        }

        private void checkTax_CheckedChanged(object sender, EventArgs e)
        {
            if(checkTax.Checked)
            {
                groupTax.Visible = true;
                groupTax.Enabled = true;
            }
            else
            {
                groupTax.Visible = false;
                groupTax.Enabled = false;
                textTax.Text = "";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("uncomplete data you need to fill the required fields !", "Uncompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Product.ProductName = textProductName.Text;
            Product.BarCode = textBarCode.Text;
            Product.StockQuantity = Convert.ToInt32(textQuantity.Text);
            Product.CategoryID = Convert.ToInt32(comboBox1.SelectedValue);
            Product.IsActive = checkActive.Checked ? true : false;
            Product.BuyingPrice = Convert.ToDecimal(textBuyingPrice.Text);
            Product.SellingPrice = Convert.ToDecimal(textSellingPrice.Text);
            Product.CreatedByUserID = clsGlobal.User.UserID;

            if(!String.IsNullOrEmpty(textTax.Text))
                Product.TaxRate = Convert.ToDecimal(textTax.Text);


            if(!String.IsNullOrEmpty(_UpdateModeImagePath)
                && _UpdateModeImagePath != _ImagePath)
            {
                if (File.Exists(_UpdateModeImagePath))
                {
                    File.Delete(_UpdateModeImagePath);
                }
            }

            if (pictureBox1.Image != null)
            {
                Product.ProductImage = _ImagePath;
                _ImagePath = string.Empty;
            }

                

            if (Product.Save())
            {
                MessageBox.Show("Product Saved Successfully", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetProductID?.Invoke(this, Product.ProductID);
                BtnSave.Enabled = false;
            }
            else
                MessageBox.Show("Operation Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TextRequired(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(String.IsNullOrEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "this Field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                e.Cancel= false;
            }
        }

        private void KeyPressNumber(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private string _saveFileOnFolder(string FilePath)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PosProductsImages");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string extension = Path.GetExtension(FilePath);

            string newFileName = $"{Guid.NewGuid()}{extension}";

            string destinationPath = Path.Combine(path, newFileName);

            File.Copy(FilePath, destinationPath, true);

            _DeleteFromFolderIfIsMarked();

            _ImagePath = destinationPath;

            return destinationPath;
        }
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Select an Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string FilePath = openFileDialog.FileName;
                string SavedPath = _saveFileOnFolder(FilePath);

                using (var img = Image.FromFile(SavedPath))
                {
                    pictureBox1.Image = new Bitmap(img);
                }

                BtnBrowse.Enabled = false; 
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _MarkDeleteImage = true;
            pictureBox1.Image = null;
            BtnBrowse.Enabled = true;
        }

        private void _DeleteFromFolderIfIsMarked()
        {
            if (_MarkDeleteImage)
            {
                if(_ImagePath != _UpdateModeImagePath)
                {
                    if (File.Exists(_ImagePath))
                    {
                        File.Delete(_ImagePath);
                    }

                    _MarkDeleteImage = false;
                    _ImagePath = "";
                }

            }
        }

        private void AddProductsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (!String.IsNullOrEmpty(_ImagePath))
            {
                if(_ImagePath != _UpdateModeImagePath)
                {
                    _MarkDeleteImage = true;
                    _DeleteFromFolderIfIsMarked();
                }
            }
        }
    }
}
