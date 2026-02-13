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
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        private string _ImagePath = ""; 
        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                _ImagePath = value;
                pictureProduct.Load(_ImagePath);
            }
        }

        private string _ProductName = ""; 
        public string ProducName
        {
            get { return _ProductName; }

            set
            {
                _ProductName = value;
                LbName.Text = _ProductName;
            }
        }

        private int _Quantity = 1;
        public int Quantity
        {
            get { return _Quantity; }

            set
            {
                _Quantity = value;
                LbQuantity.Text = "x" + _Quantity.ToString("0");
            }
        }

        private decimal _Price = 0;
        public decimal Price
        {
            get { return _Price; }

            set
            {
                _Price = value;
                LbPrice.Text = _Price.ToString("00.00") + " DH";
            }
        }


    }
}
