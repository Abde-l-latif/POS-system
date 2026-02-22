using PosBusinessLayer;
using PosPresentationLayer.SuppliersFolder;
using PosPresentationLayer.SuppliersFolder.Controls;
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
    public partial class UserDetailsWithFilter : UserControl
    {
        public UserDetailsWithFilter()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            AddUpdateUser fm = new AddUpdateUser();
            fm.UserIdSelected += _UserIdSelected;
            fm.ShowDialog();

        }

        private void _UserIdSelected(object sender, int ID)
        {
            userDetails1.LoadDataByUserID(ID);
            comboBox1.SelectedIndex = 0;
            TextBoxFilter.Text = ID.ToString();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxFilter.Text))
            {
                MessageBox.Show("Field Is Empty Lack of Information", "Lack Of Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox1.Text == "User ID")
            {
                int UserID = Convert.ToInt32(TextBoxFilter.Text);

                if (clsUsers.isUserExist(UserID))
                {
                    userDetails1.LoadDataByUserID(UserID);
                }
                else
                    MessageBox.Show("Supplier Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "First Name")
            {
                int ID = clsUsers.GetUserIDByFirstName(TextBoxFilter.Text);

                if (ID != -1)
                {
                    userDetails1.LoadDataByUserID(ID);
                }
                else
                    MessageBox.Show("User Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxFilter.KeyPress -= textFilter_KeyPress;

            if (comboBox1.Text == "User ID")
            {
                TextBoxFilter.KeyPress += textFilter_KeyPress;
            }
        }
    }
}
