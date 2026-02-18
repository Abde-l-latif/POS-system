namespace PosPresentationLayer
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCategoriesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePeopleListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSuppliersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomerListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSupplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowProductCard = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LbTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LbTotalTax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LbSubTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnQuantity = new System.Windows.Forms.Button();
            this.BtnTrash = new System.Windows.Forms.Button();
            this.searchForProducts1 = new PosPresentationLayer.ProductFolder.Controls.SearchForProducts();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.IndianRed;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.personsToolStripMenuItem,
            this.managementToolStripMenuItem,
            this.aToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.suppliersToolStripMenuItem,
            this.customersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1234, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.securityToolStripMenuItem,
            this.manageCategoriesToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.settingsToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.settingsIcon;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(86, 37);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.securityToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.securityToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.securityIcons;
            this.securityToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.securityToolStripMenuItem.Text = "Security ";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.changePasswordToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.changepasswordIcon;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // manageCategoriesToolStripMenuItem
            // 
            this.manageCategoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryToolStripMenuItem,
            this.showCategoriesListToolStripMenuItem});
            this.manageCategoriesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.manageCategoriesToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.inventory_category;
            this.manageCategoriesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageCategoriesToolStripMenuItem.Name = "manageCategoriesToolStripMenuItem";
            this.manageCategoriesToolStripMenuItem.Size = new System.Drawing.Size(202, 30);
            this.manageCategoriesToolStripMenuItem.Text = "Manage Categories";
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addCategoryToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.inventory_categoryAdd;
            this.addCategoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(212, 30);
            this.addCategoryToolStripMenuItem.Text = "Add Category";
            this.addCategoryToolStripMenuItem.Click += new System.EventHandler(this.addCategoryToolStripMenuItem_Click);
            // 
            // showCategoriesListToolStripMenuItem
            // 
            this.showCategoriesListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.showCategoriesListToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.inventory_categoryList;
            this.showCategoriesListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showCategoriesListToolStripMenuItem.Name = "showCategoriesListToolStripMenuItem";
            this.showCategoriesListToolStripMenuItem.Size = new System.Drawing.Size(212, 30);
            this.showCategoriesListToolStripMenuItem.Text = "Show Categories List";
            this.showCategoriesListToolStripMenuItem.Click += new System.EventHandler(this.showCategoriesListToolStripMenuItem_Click);
            // 
            // personsToolStripMenuItem
            // 
            this.personsToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.personsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPersonToolStripMenuItem,
            this.findPersonToolStripMenuItem});
            this.personsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.personsToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.demographic;
            this.personsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.personsToolStripMenuItem.Name = "personsToolStripMenuItem";
            this.personsToolStripMenuItem.Size = new System.Drawing.Size(94, 37);
            this.personsToolStripMenuItem.Text = "People";
            // 
            // addPersonToolStripMenuItem
            // 
            this.addPersonToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addPersonToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.person_boy;
            this.addPersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addPersonToolStripMenuItem.Name = "addPersonToolStripMenuItem";
            this.addPersonToolStripMenuItem.Size = new System.Drawing.Size(157, 30);
            this.addPersonToolStripMenuItem.Text = "Add Person";
            this.addPersonToolStripMenuItem.Click += new System.EventHandler(this.addPersonToolStripMenuItem_Click);
            // 
            // findPersonToolStripMenuItem
            // 
            this.findPersonToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.findPersonToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.FindPerson;
            this.findPersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findPersonToolStripMenuItem.Name = "findPersonToolStripMenuItem";
            this.findPersonToolStripMenuItem.Size = new System.Drawing.Size(157, 30);
            this.findPersonToolStripMenuItem.Text = "Find Person";
            this.findPersonToolStripMenuItem.Click += new System.EventHandler(this.findPersonToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managePeopleListToolStripMenuItem,
            this.manageUsersListToolStripMenuItem,
            this.manageProductToolStripMenuItem,
            this.manageSuppliersListToolStripMenuItem,
            this.manageCustomerListToolStripMenuItem});
            this.managementToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managementToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.managementToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.tools;
            this.managementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(133, 37);
            this.managementToolStripMenuItem.Text = "Management";
            // 
            // managePeopleListToolStripMenuItem
            // 
            this.managePeopleListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.managePeopleListToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.demographic;
            this.managePeopleListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.managePeopleListToolStripMenuItem.Name = "managePeopleListToolStripMenuItem";
            this.managePeopleListToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.managePeopleListToolStripMenuItem.Text = "Manage People List";
            this.managePeopleListToolStripMenuItem.Click += new System.EventHandler(this.managePeopleListToolStripMenuItem_Click);
            // 
            // manageUsersListToolStripMenuItem
            // 
            this.manageUsersListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.manageUsersListToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.users;
            this.manageUsersListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageUsersListToolStripMenuItem.Name = "manageUsersListToolStripMenuItem";
            this.manageUsersListToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.manageUsersListToolStripMenuItem.Text = "Manage Users List";
            this.manageUsersListToolStripMenuItem.Click += new System.EventHandler(this.manageUsersListToolStripMenuItem_Click);
            // 
            // manageProductToolStripMenuItem
            // 
            this.manageProductToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.manageProductToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.marshmallow;
            this.manageProductToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageProductToolStripMenuItem.Name = "manageProductToolStripMenuItem";
            this.manageProductToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.manageProductToolStripMenuItem.Text = "Manage Products List";
            this.manageProductToolStripMenuItem.Click += new System.EventHandler(this.manageProductToolStripMenuItem_Click);
            // 
            // manageSuppliersListToolStripMenuItem
            // 
            this.manageSuppliersListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.manageSuppliersListToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.supplier;
            this.manageSuppliersListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageSuppliersListToolStripMenuItem.Name = "manageSuppliersListToolStripMenuItem";
            this.manageSuppliersListToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.manageSuppliersListToolStripMenuItem.Text = "Manage Suppliers List";
            this.manageSuppliersListToolStripMenuItem.Click += new System.EventHandler(this.manageSuppliersListToolStripMenuItem_Click);
            // 
            // manageCustomerListToolStripMenuItem
            // 
            this.manageCustomerListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.manageCustomerListToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.network_diagramFind;
            this.manageCustomerListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageCustomerListToolStripMenuItem.Name = "manageCustomerListToolStripMenuItem";
            this.manageCustomerListToolStripMenuItem.Size = new System.Drawing.Size(230, 38);
            this.manageCustomerListToolStripMenuItem.Text = "Manage Customer List";
            this.manageCustomerListToolStripMenuItem.Click += new System.EventHandler(this.manageCustomerListToolStripMenuItem_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem});
            this.aToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aToolStripMenuItem.ForeColor = System.Drawing.Color.Snow;
            this.aToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.users;
            this.aToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.Size = new System.Drawing.Size(77, 37);
            this.aToolStripMenuItem.Text = "Users";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addUserToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.user_add;
            this.addUserToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(140, 30);
            this.addUserToolStripMenuItem.Text = "Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProductToolStripMenuItem,
            this.findProductToolStripMenuItem});
            this.productsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.productsToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.marshmallow;
            this.productsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(106, 37);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addNewProductToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.plus;
            this.addNewProductToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.addNewProductToolStripMenuItem.Text = "Add New Product";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.addNewProductToolStripMenuItem_Click);
            // 
            // findProductToolStripMenuItem
            // 
            this.findProductToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.findProductToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.product__1_;
            this.findProductToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findProductToolStripMenuItem.Name = "findProductToolStripMenuItem";
            this.findProductToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.findProductToolStripMenuItem.Text = "Find Product";
            this.findProductToolStripMenuItem.Click += new System.EventHandler(this.findProductToolStripMenuItem_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.suppliersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSupplierToolStripMenuItem,
            this.findSupplierToolStripMenuItem});
            this.suppliersToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.suppliersToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.supplier;
            this.suppliersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(109, 37);
            this.suppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // addNewSupplierToolStripMenuItem
            // 
            this.addNewSupplierToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addNewSupplierToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.plus;
            this.addNewSupplierToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewSupplierToolStripMenuItem.Name = "addNewSupplierToolStripMenuItem";
            this.addNewSupplierToolStripMenuItem.Size = new System.Drawing.Size(195, 30);
            this.addNewSupplierToolStripMenuItem.Text = "Add New Supplier";
            this.addNewSupplierToolStripMenuItem.Click += new System.EventHandler(this.addNewSupplierToolStripMenuItem_Click);
            // 
            // findSupplierToolStripMenuItem
            // 
            this.findSupplierToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.findSupplierToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.customer;
            this.findSupplierToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findSupplierToolStripMenuItem.Name = "findSupplierToolStripMenuItem";
            this.findSupplierToolStripMenuItem.Size = new System.Drawing.Size(195, 30);
            this.findSupplierToolStripMenuItem.Text = "Find Supplier";
            this.findSupplierToolStripMenuItem.Click += new System.EventHandler(this.findSupplierToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.customersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.findCustomerToolStripMenuItem});
            this.customersToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.customersToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.network_diagram;
            this.customersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(109, 37);
            this.customersToolStripMenuItem.Text = "Customers";
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.addCustomerToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.network_diagramAdd;
            this.addCustomerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.addCustomerToolStripMenuItem.Text = "Add Customer";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // findCustomerToolStripMenuItem
            // 
            this.findCustomerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.findCustomerToolStripMenuItem.Image = global::PosPresentationLayer.Properties.Resources.network_diagramFind;
            this.findCustomerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findCustomerToolStripMenuItem.Name = "findCustomerToolStripMenuItem";
            this.findCustomerToolStripMenuItem.Size = new System.Drawing.Size(188, 30);
            this.findCustomerToolStripMenuItem.Text = "Find Customer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowProductCard);
            this.groupBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Location = new System.Drawing.Point(4, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 508);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cards";
            // 
            // flowProductCard
            // 
            this.flowProductCard.AutoScroll = true;
            this.flowProductCard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowProductCard.Location = new System.Drawing.Point(4, 20);
            this.flowProductCard.Name = "flowProductCard";
            this.flowProductCard.Size = new System.Drawing.Size(356, 482);
            this.flowProductCard.TabIndex = 0;
            this.flowProductCard.WrapContents = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleVioletRed;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(365, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.LbTotal);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.LbTotalTax);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.LbSubTotal);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(168, 598);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 106);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(5, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "-------------------------------------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LbTotal
            // 
            this.LbTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTotal.ForeColor = System.Drawing.Color.IndianRed;
            this.LbTotal.Location = new System.Drawing.Point(83, 77);
            this.LbTotal.Name = "LbTotal";
            this.LbTotal.Size = new System.Drawing.Size(112, 17);
            this.LbTotal.TabIndex = 5;
            this.LbTotal.Text = "0.00";
            this.LbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total";
            // 
            // LbTotalTax
            // 
            this.LbTotalTax.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTotalTax.ForeColor = System.Drawing.Color.IndianRed;
            this.LbTotalTax.Location = new System.Drawing.Point(83, 47);
            this.LbTotalTax.Name = "LbTotalTax";
            this.LbTotalTax.Size = new System.Drawing.Size(112, 17);
            this.LbTotalTax.TabIndex = 3;
            this.LbTotalTax.Text = "0.00";
            this.LbTotalTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Tax";
            // 
            // LbSubTotal
            // 
            this.LbSubTotal.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbSubTotal.ForeColor = System.Drawing.Color.IndianRed;
            this.LbSubTotal.Location = new System.Drawing.Point(83, 19);
            this.LbSubTotal.Name = "LbSubTotal";
            this.LbSubTotal.Size = new System.Drawing.Size(112, 17);
            this.LbSubTotal.TabIndex = 1;
            this.LbSubTotal.Text = "0.00";
            this.LbSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "SubTotal";
            // 
            // BtnQuantity
            // 
            this.BtnQuantity.BackColor = System.Drawing.Color.IndianRed;
            this.BtnQuantity.Enabled = false;
            this.BtnQuantity.FlatAppearance.BorderSize = 0;
            this.BtnQuantity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.BtnQuantity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.BtnQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuantity.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuantity.Image = global::PosPresentationLayer.Properties.Resources.shopping_basket;
            this.BtnQuantity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuantity.Location = new System.Drawing.Point(5, 606);
            this.BtnQuantity.Name = "BtnQuantity";
            this.BtnQuantity.Size = new System.Drawing.Size(157, 28);
            this.BtnQuantity.TabIndex = 5;
            this.BtnQuantity.Text = "Quantity";
            this.BtnQuantity.UseVisualStyleBackColor = false;
            this.BtnQuantity.Click += new System.EventHandler(this.BtnQuantity_Click);
            // 
            // BtnTrash
            // 
            this.BtnTrash.BackColor = System.Drawing.Color.Tomato;
            this.BtnTrash.Enabled = false;
            this.BtnTrash.FlatAppearance.BorderSize = 0;
            this.BtnTrash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.BtnTrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Crimson;
            this.BtnTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTrash.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTrash.Image = global::PosPresentationLayer.Properties.Resources.trash_can;
            this.BtnTrash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTrash.Location = new System.Drawing.Point(5, 640);
            this.BtnTrash.Name = "BtnTrash";
            this.BtnTrash.Size = new System.Drawing.Size(157, 28);
            this.BtnTrash.TabIndex = 6;
            this.BtnTrash.Text = "Remove";
            this.BtnTrash.UseVisualStyleBackColor = false;
            this.BtnTrash.Click += new System.EventHandler(this.BtnTrash_Click);
            // 
            // searchForProducts1
            // 
            this.searchForProducts1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchForProducts1.Location = new System.Drawing.Point(366, 47);
            this.searchForProducts1.Margin = new System.Windows.Forms.Padding(4);
            this.searchForProducts1.Name = "searchForProducts1";
            this.searchForProducts1.Size = new System.Drawing.Size(873, 749);
            this.searchForProducts1.TabIndex = 1;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 799);
            this.Controls.Add(this.BtnTrash);
            this.Controls.Add(this.BtnQuantity);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchForProducts1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.MistyRose;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePeopleListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageUsersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProductToolStripMenuItem;
        private ProductFolder.Controls.SearchForProducts searchForProducts1;
        private System.Windows.Forms.ToolStripMenuItem findProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCategoriesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSuppliersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSupplierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomerListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findCustomerToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowProductCard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LbTotalTax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbSubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnQuantity;
        private System.Windows.Forms.Button BtnTrash;
    }
}