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

namespace PosPresentationLayer.CategoriesFolder
{
    public partial class CategoriesListForm : Form
    {
        DataTable DT = new DataTable();
        public CategoriesListForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _InitializeDataGrid();
        }

        private void _FillDataGrid()
        {
            DT = clsCategories.GetAllCategories();
            dataGridView1.DataSource = DT;
        }

        private void _InitializeDataGrid()
        {
            _FillDataGrid();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["CategoryID"].HeaderText = "ID";
            dataGridView1.Columns["CategoryName"].HeaderText = "Category Name";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Created At";
            dataGridView1.Columns["UpdatedAt"].HeaderText = "Updated At";
            dataGridView1.Columns["IsActive"].HeaderText = "Active";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                AddUpdateCategoryForm fm = new AddUpdateCategoryForm(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                fm.ShowDialog();

                _FillDataGrid();
            }
            else
                MessageBox.Show("Please Select first a row", "Unselected", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
