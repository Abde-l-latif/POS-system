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
    public partial class AddUpdateUser : Form
    {
        public event EventHandler<int> UserIdSelected;

        enum enMode { AddMode, UpdateMode }

        DataTable Dt = clsRoles.GetAllRoles();


        enMode _Mode = enMode.AddMode;

        int _SelectedPermission = 0;

        long? _UserPermission = 0;

        clsUsers user = new clsUsers();
        public AddUpdateUser()
        {
            _Mode = enMode.AddMode;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            BTNSave.Enabled = false;
            personDetailsWithFilter1.PersonSelected += _getPersonId;
            InitializeCheckBoxList();
        }

        public AddUpdateUser(int userID)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _Mode = enMode.UpdateMode;
            user = clsUsers.GetUserById(userID);
            personDetailsWithFilter1.PersonID = user.PersonID;
            InitializeCheckBoxList();
        }

        private void _InitializeUserPermissions()
        {
            if (clsGlobal.User.CurrentPermissions != null)
                _UserPermission = clsGlobal.User.CurrentPermissions;
            else
                _UserPermission = clsGlobal.User.Role.Permissions;
        }   

        private void InitializeCheckBoxList()
        {
            checkedListPermissions.Items.Clear();

            _InitializeUserPermissions();

            foreach (clsGlobal.Permissions p in Enum.GetValues(typeof(clsGlobal.Permissions)))
            {
                if (p == clsGlobal.Permissions.None)
                    continue;

                if((_UserPermission & (int)p) == (int)p)
                {
                    checkedListPermissions.Items.Add(p);
                }

            }
        }

        private void BTNSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("uncomplete data you need to fill the required fields !", "Uncompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_Mode == enMode.AddMode)
            {
                if (clsUsers.IsPersonAlreadyUser(user.PersonID))
                {
                    MessageBox.Show("Operation Failed this person already is a user !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    personDetailsWithFilter1.FilterField = true;
                    return;
                }

                if(clsCustomers.isPersonAlreadyCustomer(user.PersonID))
                {
                    MessageBox.Show("Operation Failed this person already is a customer !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    personDetailsWithFilter1.FilterField = true;
                    return;
                }

                if (clsSupplier.isPersonAlreadySupplier(user.PersonID))
                {
                    MessageBox.Show("Operation Failed this person already is a supplier !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    personDetailsWithFilter1.FilterField = true;
                    return;
                }

                user.UserPassword = clsGlobal.HashPassword(textPassword.Text);
            }

            foreach(var item in checkedListPermissions.CheckedItems)
            {
                _SelectedPermission |= (int)item;
            }

            if(_SelectedPermission == 0)
                user.CurrentPermissions = null;
            else
                user.CurrentPermissions = _SelectedPermission;


            user.RoleID = (int)comboBox1.SelectedValue;
            user.Username = textUsername.Text;        
            user.IsActive = checkBox1.Checked ? true : false;

            if(user.Save())
            {
                LBuserID.Text = user.UserID.ToString();
                UserIdSelected ?.Invoke(this, user.UserID);
                MessageBox.Show("Operation Done successfully !", "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BTNSave.Enabled = false; 
            }
            else
                MessageBox.Show("Operation Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _getPersonId(object sender , int id)
        {
            personDetailsWithFilter1.personDetails.EnableUpdate = false;
            personDetailsWithFilter1.FilterField = false;
            user.PersonID = id;
            BTNSave.Enabled = true; 
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
            if(_Mode == enMode.UpdateMode)
            {
                e.Cancel = false;
                return;
            }

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

        private void _fillUserData()
        {
            textUsername.Text = user.Username;
            checkBox1.Checked = user.IsActive;
            label3.Visible = false;
            textPassword.Visible = false;
            pictureBox2.Visible = false;
            LBuserID.Text = user.UserID.ToString();


            long? permissions = user.CurrentPermissions ?? user.Role.Permissions; 

            for (int i = 0; i < checkedListPermissions.Items.Count; i++)
            {
                if ((permissions & (int)checkedListPermissions.Items[i]) == (int)checkedListPermissions.Items[i])
                {
                    checkedListPermissions.SetItemChecked(i, true);
                }
            }
            
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.UpdateMode)
            {
                if (clsUsers.IsAdmin(clsGlobal.User))
                {
                    comboBox1.DataSource = Dt;
                    comboBox1.DisplayMember = "RoleName";
                    comboBox1.ValueMember = "RoleID";

                    comboBox1.SelectedIndex = comboBox1.FindStringExact(user.Role.RoleName);

                    personDetailsWithFilter1.TextField = user.PersonID.ToString();
                    personDetailsWithFilter1.FilterField = false;

                    pictureTitle.Image = Properties.Resources.operatorEdit;
                    LBtitle.Text = "Update User";
                    _fillUserData();
                }
                else
                {
                    MessageBox.Show("You don't have the permission to access this form, Only Admin can update a user !", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;

                }
            }
            else
            {
                if (!clsUsers.HasPermission(clsGlobal.User, (int)clsGlobal.Permissions.AddUsers))
                {
                    MessageBox.Show("You don't have the permission to access this form !", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                if (clsGlobal.User.Role.Permissions == -1)
                {
                    comboBox1.DataSource = Dt;
                    comboBox1.DisplayMember = "RoleName";
                    comboBox1.ValueMember = "RoleID";
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.DataSource = Dt.Select("RoleName = 'Cashier'").CopyToDataTable();
                    comboBox1.DisplayMember = "RoleName";
                    comboBox1.ValueMember = "RoleID";
                    comboBox1.SelectedIndex = 0;

                }

                pictureTitle.Image = Properties.Resources._operator;
                LBtitle.Text = "Add New User";
            }
        }
    }
}
