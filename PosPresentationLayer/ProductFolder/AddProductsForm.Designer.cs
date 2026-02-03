namespace PosPresentationLayer.ProductFolder
{
    partial class AddProductsForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBarCode = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.textProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupTax = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textTax = new System.Windows.Forms.TextBox();
            this.checkTax = new System.Windows.Forms.CheckBox();
            this.textSellingPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBuyingPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupTax.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(553, 337);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.checkActive);
            this.tabPage1.Controls.Add(this.textQuantity);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBarCode);
            this.tabPage1.Controls.Add(this.label);
            this.tabPage1.Controls.Add(this.textProductName);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 213);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 25);
            this.comboBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(11, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Categories :";
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.Checked = true;
            this.checkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkActive.Location = new System.Drawing.Point(11, 260);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(61, 21);
            this.checkActive.TabIndex = 6;
            this.checkActive.Text = "Active";
            this.checkActive.UseVisualStyleBackColor = true;
            // 
            // textQuantity
            // 
            this.textQuantity.Location = new System.Drawing.Point(12, 153);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(132, 23);
            this.textQuantity.TabIndex = 5;
            this.textQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressNumber);
            this.textQuantity.Validating += new System.ComponentModel.CancelEventHandler(this.TextRequired);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(9, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity :";
            // 
            // textBarCode
            // 
            this.textBarCode.Location = new System.Drawing.Point(11, 98);
            this.textBarCode.Name = "textBarCode";
            this.textBarCode.Size = new System.Drawing.Size(373, 23);
            this.textBarCode.TabIndex = 3;
            this.textBarCode.Validating += new System.ComponentModel.CancelEventHandler(this.TextRequired);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label.Location = new System.Drawing.Point(9, 78);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(66, 17);
            this.label.TabIndex = 2;
            this.label.Text = "BarCode :";
            // 
            // textProductName
            // 
            this.textProductName.Location = new System.Drawing.Point(9, 41);
            this.textProductName.Name = "textProductName";
            this.textProductName.Size = new System.Drawing.Size(373, 23);
            this.textProductName.TabIndex = 1;
            this.textProductName.Validating += new System.ComponentModel.CancelEventHandler(this.TextRequired);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product Name :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupTax);
            this.tabPage2.Controls.Add(this.checkTax);
            this.tabPage2.Controls.Add(this.textSellingPrice);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBuyingPrice);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(545, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Price&Tax";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupTax
            // 
            this.groupTax.Controls.Add(this.label7);
            this.groupTax.Controls.Add(this.textTax);
            this.groupTax.Enabled = false;
            this.groupTax.Location = new System.Drawing.Point(17, 162);
            this.groupTax.Name = "groupTax";
            this.groupTax.Size = new System.Drawing.Size(147, 49);
            this.groupTax.TabIndex = 7;
            this.groupTax.TabStop = false;
            this.groupTax.Text = "Tax";
            this.groupTax.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "%";
            // 
            // textTax
            // 
            this.textTax.Location = new System.Drawing.Point(6, 20);
            this.textTax.Name = "textTax";
            this.textTax.Size = new System.Drawing.Size(74, 23);
            this.textTax.TabIndex = 6;
            this.textTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressNumber);
            // 
            // checkTax
            // 
            this.checkTax.AutoSize = true;
            this.checkTax.Location = new System.Drawing.Point(18, 134);
            this.checkTax.Name = "checkTax";
            this.checkTax.Size = new System.Drawing.Size(147, 21);
            this.checkTax.TabIndex = 5;
            this.checkTax.Text = "You want to add Tax";
            this.checkTax.UseVisualStyleBackColor = true;
            this.checkTax.CheckedChanged += new System.EventHandler(this.checkTax_CheckedChanged);
            // 
            // textSellingPrice
            // 
            this.textSellingPrice.Location = new System.Drawing.Point(18, 95);
            this.textSellingPrice.Name = "textSellingPrice";
            this.textSellingPrice.Size = new System.Drawing.Size(154, 23);
            this.textSellingPrice.TabIndex = 4;
            this.textSellingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressNumber);
            this.textSellingPrice.Validating += new System.ComponentModel.CancelEventHandler(this.TextRequired);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(15, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Selling Price :";
            // 
            // textBuyingPrice
            // 
            this.textBuyingPrice.Location = new System.Drawing.Point(18, 39);
            this.textBuyingPrice.Name = "textBuyingPrice";
            this.textBuyingPrice.Size = new System.Drawing.Size(154, 23);
            this.textBuyingPrice.TabIndex = 2;
            this.textBuyingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressNumber);
            this.textBuyingPrice.Validating += new System.ComponentModel.CancelEventHandler(this.TextRequired);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(15, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Buying Price :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnCancel);
            this.tabPage3.Controls.Add(this.BtnBrowse);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(545, 307);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Image";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Gray;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnCancel.Location = new System.Drawing.Point(270, 168);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(67, 28);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.BackColor = System.Drawing.Color.IndianRed;
            this.BtnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBrowse.FlatAppearance.BorderSize = 0;
            this.BtnBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.BtnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.BtnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBrowse.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnBrowse.Location = new System.Drawing.Point(194, 168);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(67, 28);
            this.BtnBrowse.TabIndex = 1;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = false;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(194, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Products";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.IndianRed;
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Brown;
            this.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RosyBrown;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.BtnSave.Location = new System.Drawing.Point(439, 401);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(116, 28);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 436);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddProductsForm";
            this.Text = "AddProductsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddProductsForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupTax.ResumeLayout(false);
            this.groupTax.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBarCode;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textSellingPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBuyingPrice;
        private System.Windows.Forms.CheckBox checkTax;
        private System.Windows.Forms.TextBox textTax;
        private System.Windows.Forms.GroupBox groupTax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}