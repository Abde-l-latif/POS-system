using PosBusinessLayer;
using PosPresentationLayer.CategoriesFolder;
using PosPresentationLayer.CustomerFolder;
using PosPresentationLayer.PeopleFolder;
using PosPresentationLayer.ProductFolder;
using PosPresentationLayer.ProductFolder.Controls;
using PosPresentationLayer.PurchaseFolder;
using PosPresentationLayer.RolesFolder;
using PosPresentationLayer.SuppliersFolder;
using PosPresentationLayer.UsersFolder;
using PosPresentationLayer.utilitiesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PosPresentationLayer
{
    public partial class MainScreen : Form
    {

        private decimal _Subtotal = 0; 
        private decimal _AmountTax = 0;
        private int _SelectedControlIndex = -1;
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
            foreach(ProductCard card in flowProductCard.Controls.OfType<ProductCard>())
            {
                if(card.ProducName == Product.ProductName)
                {
                    card.Quantity++;
                    _Recalculate();
                    card.ProductCard_Load(null, null);
                    return;
                }
            }

            ProductCard Card = new ProductCard();

            Card.ProductSelected += CardProductSelected;

            if(!String.IsNullOrEmpty(Product.ProductImage))
                Card.ImagePath = Product.ProductImage;

            Card.ProducName = Product.ProductName;

            Card.StockQuantity = Product.StockQuantity;

            Card.Quantity = 1;

            Card.Tax = Product.TaxRate;

            Card.Price = Product.SellingPrice;

            flowProductCard.Controls.Add(Card);

            SetCalculation(Card);

        }

        private void CardProductSelected(object sender, int Index)
        {
            BtnQuantity.Enabled = true;
            BtnTrash.Enabled = true;

            _SelectedControlIndex = Index;
        }

        private void SetCalculation(ProductCard Card)
        {
            _Subtotal += Card.SubTotal;
            _AmountTax += Card.TaxAmount;

            LbSubTotal.Text = _Subtotal.ToString("0.00");
            LbTotalTax.Text = _AmountTax.ToString("0.00");
            LbTotal.Text = (_Subtotal + _AmountTax).ToString("0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowProductCard.Controls.Clear();
            BtnQuantity.Enabled = false;
            BtnTrash.Enabled = false;
            _Subtotal = 0;
            _AmountTax = 0;
            LbSubTotal.Text = "0.00";
            LbTotalTax.Text = "0.00";
            LbTotal.Text = "0.00";
        }

        private void BtnQuantity_Click(object sender, EventArgs e)
        {
            ProductQuantityForm fm = new ProductQuantityForm(((ProductCard)flowProductCard.Controls[_SelectedControlIndex]).StockQuantity);
            fm.QuantitySelected += QuantitySelected;
            fm.ShowDialog();
        }

        private void QuantitySelected(object sender, int Quantity)
        {
            ProductCard Card = (ProductCard)flowProductCard.Controls[_SelectedControlIndex];
            Card.Quantity = Quantity;
            Card.ProductCard_Load(null, null);
            _Recalculate();
        }

        private void _Recalculate()
        {
            _Subtotal = 0;
            _AmountTax = 0;

            foreach (ProductCard Card in flowProductCard.Controls.OfType<ProductCard>())
            {
                _Subtotal += Card.SubTotal;
                _AmountTax += Card.TaxAmount;
            }

            LbSubTotal.Text = _Subtotal.ToString("0.00");
            LbTotalTax.Text = _AmountTax.ToString("0.00");
            LbTotal.Text = (_Subtotal + _AmountTax).ToString("0.00");
        }

        private void BtnTrash_Click(object sender, EventArgs e)
        {
            flowProductCard.Controls.RemoveAt(_SelectedControlIndex);
            _Recalculate();
            BtnTrash.Enabled = false;
            BtnQuantity.Enabled = false;
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
            AddUpdateUser fm = new AddUpdateUser();
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

        private void manageCustomerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ManageCustomersList fm = new ManageCustomersList();
            fm.ShowDialog();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateCustomersForm fm = new AddUpdateCustomersForm();
            fm.ShowDialog();
        }

        private void findCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindCustomerForm fm = new FindCustomerForm();
            fm.ShowDialog();
        }

        private void findUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindUserForm fm = new FindUserForm();
            fm.ShowDialog();
        }

        private void addRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateRoles fm = new AddUpdateRoles();
            fm.ShowDialog();
        }

        private void rolesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolesListForm fm = new RolesListForm();
            fm.ShowDialog();
        }

        private void addPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdatePurchaseForm fm = new AddUpdatePurchaseForm();
            fm.ShowDialog();
        }
    }
}
