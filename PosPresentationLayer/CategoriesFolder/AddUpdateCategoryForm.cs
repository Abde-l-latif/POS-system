using PosBusinessLayer;
using PosPresentationLayer.Properties;
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
    public partial class AddUpdateCategoryForm : Form
    {
        enum enMode { AddMode , UpdateMode }
        enMode _Mode = enMode.AddMode;

        clsCategories _Category = new clsCategories();
        public AddUpdateCategoryForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _Mode = enMode.AddMode ;

        }

        public AddUpdateCategoryForm(int CategoryID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _Category = clsCategories.GetCategoryByID(CategoryID);
            _Mode = enMode.UpdateMode;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textName, "This Field is Required fill it");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textName, "");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("uncomplete data you need to fill the required fields !", "Uncompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Category.CategoryName = textName.Text;
            _Category.IsActive = checkBox1.Checked;

            if(_Category.Save())
            {
                MessageBox.Show("Category Saved Successfully", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnSave.Enabled = false; 
            }
            else
                MessageBox.Show("Operation Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _InitializeUiUpdateMode()
        {
            textName.Text = _Category.CategoryName;
            checkBox1.Checked = _Category.IsActive;
        }

        private void AddUpdateCategoryForm_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddMode)
            {
                LBtitle.Text = "Add Category";
                pictureTitle.Image = Resources.inventory_categoryAddScreen;
            }
            else
            {
                LBtitle.Text = "Update Category";
                pictureTitle.Image = Resources.inventory_categoryUpdate;

                _InitializeUiUpdateMode();
            }
        }
    }
}
