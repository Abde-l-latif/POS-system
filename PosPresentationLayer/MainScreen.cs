using PosPresentationLayer.utilitiesFolder;
using System;
using System.Windows.Forms;
using PosPresentationLayer.UsersFolder;
using PosPresentationLayer.PeopleFolder;
using PosPresentationLayer.ProductFolder;
using PosPresentationLayer.CategoriesFolder;

namespace PosPresentationLayer
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            menuStrip1.Renderer = new CustomMenuRenderer();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserPassword fm = new ChangeUserPassword();
            fm.ShowDialog();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdatePersonScreen fm = new AddUpdatePersonScreen();
            fm.ShowDialog();
        }

        private void managePeopleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople fm = new ManagePeople();
            fm.ShowDialog();
        }

        private void findPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindPerson fm = new FindPerson();
            fm.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser fm = new AddUser();
            fm.ShowDialog();
        }

        private void manageUsersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsersForm fm = new ManageUsersForm();
            fm.ShowDialog();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateProductsForm fm = new AddUpdateProductsForm();
            fm.ShowDialog();
        }

        private void manageProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProducts fm = new ManageProducts();
            fm.ShowDialog();
        }

        private void findProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindProductForm fm = new FindProductForm();
            fm.ShowDialog();
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateCategoryForm fm = new AddUpdateCategoryForm();
            fm.ShowDialog();
        }

        private void showCategoriesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriesListForm fm = new CategoriesListForm();
            fm.ShowDialog();
        }
    }
}
