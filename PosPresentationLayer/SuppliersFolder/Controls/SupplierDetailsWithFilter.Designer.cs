namespace PosPresentationLayer.SuppliersFolder.Controls
{
    partial class SupplierDetailsWithFilter
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnAddSupplier = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.TextBoxFilter = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.supplierDetails1 = new PosPresentationLayer.SuppliersFolder.Controls.SupplierDetails();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAddSupplier);
            this.groupBox2.Controls.Add(this.BtnSearch);
            this.groupBox2.Controls.Add(this.TextBoxFilter);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Supplier";
            // 
            // BtnAddSupplier
            // 
            this.BtnAddSupplier.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnAddSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddSupplier.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddSupplier.Image = global::PosPresentationLayer.Properties.Resources.plus;
            this.BtnAddSupplier.Location = new System.Drawing.Point(579, 18);
            this.BtnAddSupplier.Name = "BtnAddSupplier";
            this.BtnAddSupplier.Size = new System.Drawing.Size(39, 23);
            this.BtnAddSupplier.TabIndex = 24;
            this.BtnAddSupplier.UseVisualStyleBackColor = false;
            this.BtnAddSupplier.Click += new System.EventHandler(this.BtnAddSupplier_Click);
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
            // TextBoxFilter
            // 
            this.TextBoxFilter.Location = new System.Drawing.Point(240, 19);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(170, 20);
            this.TextBoxFilter.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Supplier ID",
            "First Name"});
            this.comboBox1.Location = new System.Drawing.Point(78, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            // supplierDetails1
            // 
            this.supplierDetails1.Location = new System.Drawing.Point(2, 62);
            this.supplierDetails1.Name = "supplierDetails1";
            this.supplierDetails1.Size = new System.Drawing.Size(636, 334);
            this.supplierDetails1.TabIndex = 4;
            // 
            // SupplierDetailsWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.supplierDetails1);
            this.Controls.Add(this.groupBox2);
            this.Name = "SupplierDetailsWithFilter";
            this.Size = new System.Drawing.Size(641, 397);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnAddSupplier;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TextBoxFilter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private SupplierDetails supplierDetails1;
    }
}
