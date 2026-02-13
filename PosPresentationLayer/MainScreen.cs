using PosPresentationLayer.utilitiesFolder;
using System;
using System.Windows.Forms;
using PosPresentationLayer.UsersFolder;
using PosPresentationLayer.PeopleFolder;
using PosPresentationLayer.ProductFolder;
using PosPresentationLayer.CategoriesFolder;
using PosPresentationLayer.SuppliersFolder;
using PosBusinessLayer;
using PosPresentationLayer.ProductFolder.Controls;

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
            searchForProducts1.ProductInfoSelected += SetProductCard;
        }

        private void SetProductCard(object sender, clsProducts Product)
        {
            ProductCard Card = new ProductCard();

            if(!String.IsNullOrEmpty(Product.ProductImage))
                Card.ImagePath = Product.ProductImage;

            Card.ProducName = Product.ProductName;

            Card.Quantity = 1;

            Card.Price = Product.SellingPrice;

            flowProductCard.Controls.Add(Card);
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

        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateSupplierForm fm = new AddUpdateSupplierForm();
            fm.ShowDialog();
        }

        private void manageSuppliersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageSupplierList fm = new ManageSupplierList();
            fm.ShowDialog();
        }

        private void findSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindSupplierForm fm = new FindSupplierForm();
            fm.ShowDialog();
        }


    }
}
