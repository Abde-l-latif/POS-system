namespace PosPresentationLayer.ProductFolder.Controls
{
    partial class ProductDetailsWithFilter
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TextBoxFilter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAddProduct = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.productDetails1 = new PosPresentationLayer.ProductFolder.Controls.ProductDetails();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Filter : ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Product ID",
            "BarCode",
            "Product Name"});
            this.comboBox1.Location = new System.Drawing.Point(78, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TextBoxFilter
            // 
            this.TextBoxFilter.Location = new System.Drawing.Point(240, 19);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(170, 20);
            this.TextBoxFilter.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAddProduct);
            this.groupBox2.Controls.Add(this.BtnSearch);
            this.groupBox2.Controls.Add(this.TextBoxFilter);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(10, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Product";
            // 
            // BtnAddProduct
            // 
            this.BtnAddProduct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddProduct.Image = global::PosPresentationLayer.Properties.Resources.plus;
            this.BtnAddProduct.Location = new System.Drawing.Point(579, 18);
            this.BtnAddProduct.Name = "BtnAddProduct";
            this.BtnAddProduct.Size = new System.Drawing.Size(39, 23);
            this.BtnAddProduct.TabIndex = 24;
            this.BtnAddProduct.UseVisualStyleBackColor = false;
            this.BtnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Image = global::PosPresentationLayer.Properties.Resources.search__1_;
            this.BtnSearch.Location = new System.Drawing.Point(421, 18);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(43, 22);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // productDetails1
            // 
            this.productDetails1.Location = new System.Drawing.Point(3, 55);
            this.productDetails1.Name = "productDetails1";
            this.productDetails1.Size = new System.Drawing.Size(638, 260);
            this.productDetails1.TabIndex = 3;
            // 
            // ProductDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.productDetails1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ProductDetailsWithFilter";
            this.Size = new System.Drawing.Size(649, 316);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox TextBoxFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnAddProduct;
        private ProductDetails productDetails1;
    }
}
