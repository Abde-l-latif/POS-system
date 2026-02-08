using PosBusinessLayer;
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

namespace PosPresentationLayer.ProductFolder.Controls
{
    public partial class SearchForProducts : UserControl
    {
        DataTable DT;
        const short _PageSize = 8;
        short _Page = 0;
        string _Column = ""; 
        string _OrderBy = "";
        Timer _searchTimer = new Timer();

        enum enMode { LoadMode , SearchMode }

        enMode _Mode = enMode.LoadMode;

        public SearchForProducts()
        {
            InitializeComponent();
            _InitializePreviousNextButton();
            _searchTimer.Interval = 400; 
            _searchTimer.Tick += SearchTimer_Tick;
            comboSort.SelectedIndex = 0;
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();

            _Page = 0;
            _CreateProductBoxes();
        }

        private void _InitializePreviousNextButton()
        {
            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
        }

        private void _PreparePreviousNextButton()
        {
            if (DT.Rows.Count > _PageSize)
            {
                button1.Visible = true;
                button1.Enabled = true;
                DT.Rows.RemoveAt(_PageSize);
            }
            else
            {
                button1.Visible = false;
                button1.Enabled = false;
            }

            if (_Page > 0)
            {
                button2.Visible = true;
                button2.Enabled = true;
            }
            else
            {
                button2.Visible = false;
                button2.Enabled = false;
            }
        }
        private void _CreateProductBoxes()
        {
            if(_Mode == enMode.LoadMode)
            {
                DT = clsProducts.GetAllProducts(_Page, _PageSize, _Column, _OrderBy);
            }
            else if(_Mode == enMode.SearchMode)
            {
                if (String.IsNullOrEmpty(textSearch.Text))
                {
                    _InitializePreviousNextButton();
                    return;
                }

                DT = clsProducts.GetProductsByName(textSearch.Text, _Page, _PageSize);
            }

            flowLayoutPanel1.Controls.Clear();

            _PreparePreviousNextButton();

            if (DT != null && DT.Rows.Count > 0)
            {
                foreach (DataRow dr in DT.Rows)
                {
                    ProductBoxControl box = new ProductBoxControl();

                    box.ProductID = Convert.ToInt32(dr["ProductID"]);
                    box.ProductPrice = Convert.ToDecimal(dr["SellingPrice"]);
                    box.ProdName = Convert.ToString(dr["ProductName"]);

                    if (Convert.ToString(dr["ProductImage"]) == null)
                    {
                        box.ProductPicture = "";
                    }
                    else
                        box.ProductPicture = Convert.ToString(dr["ProductImage"]);

                    flowLayoutPanel1.Controls.Add(box);
                }

            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            _Mode = enMode.SearchMode;

            _searchTimer.Stop();
            _searchTimer.Start();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _Page++;

            _CreateProductBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(_Page > 0)
                _Page--;


            _CreateProductBoxes();
        }

        private void SearchForProducts_Load(object sender, EventArgs e)
        {
            _CreateProductBoxes();
        }

        private void comboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Mode = enMode.LoadMode;

            switch (comboSort.Text)
            {
                case "Name Asc":
                    {
                        _Column = "ProductName";
                        _OrderBy = "ASC"; 
                        break; 
                    }
                case "Name Desc":
                    {
                        _Column = "ProductName";
                        _OrderBy = "DESC";
                        break;
                    }
                case "Price Desc":
                    {
                        _Column = "SellingPrice";
                        _OrderBy = "DESC";
                        break;
                    }
                case "Price Asc":
                    {
                        _Column = "SellingPrice";
                        _OrderBy = "ASC";
                        break;
                    }
            }
            _CreateProductBoxes();
        }
    }
}
