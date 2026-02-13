namespace PosPresentationLayer.SuppliersFolder
{
    partial class SupplierDetailsForm
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
            this.LBtitle = new System.Windows.Forms.Label();
            this.supplierDetails1 = new PosPresentationLayer.SuppliersFolder.Controls.SupplierDetails();
            this.SuspendLayout();
            // 
            // LBtitle
            // 
            this.LBtitle.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBtitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LBtitle.Location = new System.Drawing.Point(96, 9);
            this.LBtitle.Name = "LBtitle";
            this.LBtitle.Size = new System.Drawing.Size(433, 31);
            this.LBtitle.TabIndex = 28;
            this.LBtitle.Text = "Supplier Details";
            this.LBtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // supplierDetails1
            // 
            this.supplierDetails1.Location = new System.Drawing.Point(-1, 43);
            this.supplierDetails1.Name = "supplierDetails1";
            this.supplierDetails1.Size = new System.Drawing.Size(636, 338);
            this.supplierDetails1.TabIndex = 29;
            // 
            // SupplierDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 382);
            this.Controls.Add(this.supplierDetails1);
            this.Controls.Add(this.LBtitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SupplierDetailsForm";
            this.Text = "SupplierDetailsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LBtitle;
        private Controls.SupplierDetails supplierDetails1;
    }
}