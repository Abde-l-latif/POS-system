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
    public partial class SearchForProducts : UserControl
    {
        DataTable DT;
        const short _PageSize = 8;
        short _Page = 0;
        Timer _searchTimer = new Timer();

        public SearchForProducts()
        {
            InitializeComponent();
            _InitializePreviousNextButton();
            _searchTimer.Interval = 400; 
            _searchTimer.Tick += SearchTimer_Tick;
            panel1.Visible = true;
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop(); 

            _Page = 0;
            flowLayoutPanel1.Controls.Clear();
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
            DT = clsProducts.GetProductsByName(textSearch.Text, _Page, _PageSize);

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
            _InitializePreviousNextButton();
            
            _searchTimer.Stop();
            _searchTimer.Start();


            if (String.IsNullOrEmpty(textSearch.Text))
            {
               panel1.Visible = true;
                return;
            }
            else
            {
                panel1.Visible = false;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            _Page++;

            _CreateProductBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            if(_Page > 0)
                _Page--;


            _CreateProductBoxes();
        }
    }
}
