using Microsoft.Win32;
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

namespace PosPresentationLayer
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            clsUsers User = clsUsers.LoginAccount(TBUsername.Text, clsGlobal.HashPassword(TBPassword.Text));

            if (User == null)
                MessageBox.Show("Wrong username or password try again" , "Authentication" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                if(ChbRemember.Checked)
                {
                    string ProtectedKey = clsGlobal.GenerateProtectedKey(); 

                    clsGlobal.RegisterKey(ProtectedKey);

                    string EncryptedPass = clsGlobal.AESencrypt(TBPassword.Text , ProtectedKey);

                    clsGlobal.RegisterAccount(TBUsername.Text, EncryptedPass);
                }
                else
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\POS"))
                    {
                        if (key != null)
                        {
                            clsGlobal.removeAccountFromRegistry();
                        }
                    }
                }

                clsGlobal.User = User;
                this.Hide(); 
                MainScreen fm = new MainScreen();
                fm.Show();
            }
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\POS"))
            {
                if (key != null)
                {
                    string user = key.GetValue("Username").ToString();
                    string pass = clsGlobal.DecryptAES(key.GetValue("Password").ToString(), key.GetValue("Key").ToString());
                    ChbRemember.Checked = true;
                    TBUsername.Text = user;
                    TBPassword.Text = pass;
                }
                else
                    ChbRemember.Checked = false;
            }
        }
    }
}
