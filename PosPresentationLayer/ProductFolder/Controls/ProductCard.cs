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
        private bool _IsSelected = false;   
        private Color _OriginalColor; 

        public event EventHandler<int> ProductSelected;
        public ProductCard()
        {
            InitializeComponent();
            _OriginalColor = this.BackColor;
            RegisterEvents(this);
        }

        private void RegisterEvents(Control control)
        {
            control.Click += Control_Click;

            foreach (Control child in control.Controls)
            {
                RegisterEvents(child);
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {

            if(this.Parent is FlowLayoutPanel parentPanel)
            {
                foreach (ProductCard card in parentPanel.Controls.OfType<ProductCard>())
                {
                    if (card != this)
                        card.IsSelected = false;
                    else
                    {
                        this.IsSelected = true;
                        int Index = parentPanel.Controls.GetChildIndex(this);
                        ProductSelected?.Invoke(this, Index);
                    }

                }

            }
        }

        public ProductCard(ProductCard other)
        {
            InitializeComponent();

            this.ProducName = other.ProducName;
            this.ImagePath = other.ImagePath;
            this.Price = other.Price;
            this.StockQuantity = other.StockQuantity;
            this.Quantity = other.Quantity;
            this.Price = other.Price;
            this.Tax = other.Tax;

            _OriginalColor = this.BackColor;
        }

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.BackColor = _IsSelected ? Color.Pink : _OriginalColor;
            }
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

        private int _StockQuantity = 1;
        public int StockQuantity
        {
            get { return _StockQuantity; }

            set
            {
                _StockQuantity = value;
            }
        }

        private int _Quantity = 1;
        public int Quantity
        {
            get { return _Quantity; }

            set
            {
                _Quantity = value;
            }
        }

        private decimal _Price = 0;
        public decimal Price
        {
            get { return _Price; }

            set
            {
                _Price = value;                
            }
        }

        private decimal? _Tax = 0;
        public decimal? Tax
        {
            get { return _Tax; }

            set
            {
                _Tax = value;
            }
        }


        public decimal SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }

        public decimal TaxAmount
        {
            get
            {
                return Convert.ToDecimal(SubTotal * (Tax / 100));
            }
        }

        public decimal LineTotal
        {
            get
            {
                return Convert.ToDecimal(SubTotal + TaxAmount);
            }
        }

        public void ProductCard_Load(object sender, EventArgs e)
        {
            LbPrice.Text = SubTotal.ToString("0.00") + " DH";
            LbQuantity.Text = "x" + _Quantity.ToString("0");
        }
    }
}
