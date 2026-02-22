using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.RolesFolder
{
    public partial class AddUpdateRoles : Form
    {
        clsRoles Role = new clsRoles();

        int _Permissions = 0;

        enum enMode { AddMode , UpdateMode }

        enMode Mode = enMode.AddMode;
        public AddUpdateRoles()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Mode = enMode.AddMode;
        }

        public AddUpdateRoles(int RoleID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Mode = enMode.UpdateMode;
            Role = clsRoles.GetRoleByID(RoleID);
        }

        private void InitializePermissions()
        {
            if(Mode == enMode.UpdateMode)
            {
                foreach (clsGlobal.Permissions P in Enum.GetValues(typeof(clsGlobal.Permissions)))
                {
                    if (P == clsGlobal.Permissions.None)
                    {
                        continue;
                    }

                    if((Role.Permissions & (int)P) == (int)P)
                    {
                        checkedListBox1.Items.Add(P, true);
                        continue;
                    }

                    checkedListBox1.Items.Add(P, false);
                }
            }
            else
            {
                foreach (clsGlobal.Permissions P in Enum.GetValues(typeof(clsGlobal.Permissions)))
                {
                    if (P == clsGlobal.Permissions.None)
                    {
                        continue;
                    }

                    checkedListBox1.Items.Add(P);
                }
            }
                
        }

        private void AddUpdateRoles_Load(object sender, EventArgs e)
        {
            InitializePermissions();

            if (Mode == enMode.AddMode)
            {
                LbTitle.Text = "Add New Role";
                pictureTitle.Image = Properties.Resources.role_addTitle;
            }
            else
            {
                LbTitle.Text = "Update Role";
                pictureTitle.Image = Properties.Resources.role_editTitle;
                LBRoleID.Text = Role.RoleID.ToString();
                textRoleName.Text = Role.RoleName;
            }
        }

        private void BTNSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("uncomplete data you need to fill the required fields !", "Uncompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Role.RoleName = textRoleName.Text;

            foreach(var item in checkedListBox1.CheckedItems)
            {
                _Permissions |= (int)item;
            }

            Role.Permissions = _Permissions;

            if (Role.Save())
            {
                MessageBox.Show("Role Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LBRoleID.Text = Role.RoleID.ToString();
                BTNSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed To Save Role", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textRoleName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textRoleName.Text))
            {
                errorProvider1.SetError(textRoleName, "this field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textRoleName, "");
                e.Cancel = false;
            }
        }
    }
}
