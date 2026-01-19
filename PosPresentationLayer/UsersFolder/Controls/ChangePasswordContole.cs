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

namespace PosPresentationLayer.UsersFolder.Controls
{
    public partial class ChangePasswordContole : UserControl
    {
        public ChangePasswordContole()
        {
            InitializeComponent();
        }

        private void TBcurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(TBcurrentPass.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(TBcurrentPass, "this Field is required!");
            } else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBcurrentPass, "");
            }
        }

        private void TBnewPass_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(TBnewPass.Text) || TBnewPass.Text.Length < 8)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBnewPass, "this Field is required! at least 8 characters");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBnewPass, "");
            }
        }

        private void TBconfirmPass_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(TBconfirmPass.Text) || TBnewPass.Text != TBconfirmPass.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(TBconfirmPass, "you need to confirm your new password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(TBconfirmPass, "");
            }
        }

        private void DisableAllTextBox()
        {
            TBconfirmPass.Enabled = false;
            TBnewPass.Enabled = false;
            TBcurrentPass.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Operation Failed some fieled is required and you didn't fill them" , "validation" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            clsUsers user;

            user = clsUsers.GetUserById(clsGlobal.User.UserID); 

            if (user != null)
            {
                if(MessageBox.Show("Are you sure you wanna change password", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    user.UserPassword = clsGlobal.HashPassword(TBnewPass.Text);
                    if (user.Save())
                    {
                        MessageBox.Show("Operation succeeded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BTNchangePass.Enabled = false;
                        DisableAllTextBox();
                    }
                    else
                        MessageBox.Show("Operation Failed Try again", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("Operation has been Canceled", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("User Not Found !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
