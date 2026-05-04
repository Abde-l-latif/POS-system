using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PosPresentationLayer.PurchaseItemFolder
{
    public partial class UpdatePurchaseItem : Form
    {

        public event EventHandler<int> UpdatedQuantity;
        public UpdatePurchaseItem()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textQuantity.KeyPress += KeyPress_ValidateNumeric;

        }

        private void KeyPress_ValidateNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdatedQuantity?.Invoke(this, Convert.ToInt32(textQuantity.Text));

            this.Close();
        }

        private void textQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textQuantity.Text))
            {
                errorProvider1.SetError(textQuantity, "This field is required.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textQuantity, string.Empty);
                e.Cancel = false;
            }
        }
    }
}
