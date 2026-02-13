using PosPresentationLayer.Properties;
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
    public partial class ProductBoxControl : UserControl
    {

        public event EventHandler<int> ProductClicked; 
        public ProductBoxControl()
        {
            InitializeComponent();
            _registerClick(this);
        }

        private void _registerClick(Control Controle)
        {
            Controle.Click += ProductBoxControl_Click;

            foreach (Control c in Controle.Controls)
            {
                _registerClick(c);

            }
        }



        public int ProductID { get; set; }

        public string ProdName
        {
            get; set;
        }

        public string ProductPicture
        {
            get; set;
        }

        public decimal ProductPrice
        {
            get; set;
        }


        private void ProductBoxControl_Load(object sender, EventArgs e)
        {
            LbProductName.Text = ProdName;
            LBPrice.Text = ProductPrice.ToString("0.00");
            
            if(!String.IsNullOrEmpty(ProductPicture))
            {
                using (var img = Image.FromFile(ProductPicture))
                {
                    ProductPic.Image = new Bitmap(img);
                }
            }
            else
                ProductPic.Image = Resources.box;
        }

        private void ProductBoxControl_Click(object sender, EventArgs e)
        {
            ProductClicked?.Invoke(this, ProductID);
        }
    }
}
