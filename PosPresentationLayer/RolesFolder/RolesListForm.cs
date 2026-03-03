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

namespace PosPresentationLayer.RolesFolder
{
    public partial class RolesListForm : Form
    {
        public RolesListForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = clsRoles.GetAllRoles();
            InitializeDataGrid();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeDataGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["RoleID"].HeaderText = "ID";
            dataGridView1.Columns["RoleName"].HeaderText = "Role Name";
            dataGridView1.Columns["Permissions"].HeaderText = "Permissions";
            LbRecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ReloadDataGrid()
        {
            dataGridView1.DataSource = clsRoles.GetAllRoles();
            LbRecords.Text = Convert.ToString(dataGridView1.Rows.Count) + " Records";
        }

        private void deleteRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a role First.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int RoleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            clsRoles Role = clsRoles.GetRoleByID(RoleID);

            if(Role != null)
            {

                if (clsGlobal.User.Role.Permissions != -1)
                {
                    MessageBox.Show("You don't have the permission to access to Delete!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(Role.Delete())
                {
                    MessageBox.Show("User Deleted successfully", "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ReloadDataGrid();
                }
                else
                    MessageBox.Show("Operation failed, this role is being used by a user !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void updateRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a role First.", "No Role Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int RoleID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            AddUpdateRoles fm = new AddUpdateRoles(RoleID);

            fm.ShowDialog();

            _ReloadDataGrid();
        }
    }
}
