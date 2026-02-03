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

namespace PosPresentationLayer.UsersFolder
{
    public partial class AddUser : Form
    {

        clsUsers user = new clsUsers();
        public AddUser()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            BTNSave.Enabled = false;
            comboBox1.DataSource = clsRoles.GetAllRoles();
            comboBox1.DisplayMember = "RoleName";
            comboBox1.ValueMember = "RoleID";
            comboBox1.SelectedIndex = 0;
            personDetailsWithFilter1.PersonSelected += _getPersonId;
        }

        private void BTNSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("uncomplete data you need to fill the required fields !", "Uncompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.RoleID = (int)comboBox1.SelectedValue;
            user.Username = textUsername.Text;
            user.UserPassword = clsGlobal.HashPassword(textPassword.Text);
            user.IsActive = checkBox1.Checked ? true : false;

            if(user.Save())
            {
                LBuserID.Text = user.UserID.ToString();
                MessageBox.Show("Operation Done successfully !", "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNSave.Enabled = false; 
            }
            else
                MessageBox.Show("Operation Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _getPersonId(object sender , int id)
        {
            if(!clsUsers.IsPersonAlreadyUser(id))
            {
                user.PersonID = id;
                BTNSave.Enabled = true; 
            }
            else
            {
                MessageBox.Show("Operation Failed this person already is a user !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                personDetailsWithFilter1.FilterField = true;
            }
        }

        private void textUsername_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textUsername.Text))
            {
                errorProvider1.SetError(textUsername, "this field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textUsername, "");
                e.Cancel = false;
            }
        }

        private void textPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textUsername.Text) || textPassword.Text.Length < 8)
            {
                errorProvider1.SetError(textPassword, "this field is required, Minimum characters is 8");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textPassword, "");
                e.Cancel = false;
            }
        }
    }
}
