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
    public partial class ProductQuantityForm : Form
    {

        public event EventHandler<int> QuantitySelected;
        private int _StockQuantity;

        public ProductQuantityForm(int StockQuantity)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _StockQuantity = StockQuantity;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textCalc.Text))
            {
                MessageBox.Show("Please enter a quantity ." , "Lack of info" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(textCalc.Text) <= 0)
            {
                MessageBox.Show("Minimum Quantity is 1" , "" , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(textCalc.Text) > _StockQuantity)
            {
                MessageBox.Show($"Maximum Quantity on this product is {_StockQuantity} .", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            QuantitySelected?.Invoke(this, Convert.ToInt32(textCalc.Text));
            this.Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button Btn = sender as Button;

            if (Btn != null)
            {
                textCalc.Text += Btn.Tag.ToString();
            }
        }
    }
}
