namespace PosPresentationLayer.ProductFolder
{
    partial class ProductDetailsForm
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
            this.productDetails1 = new PosPresentationLayer.ProductFolder.Controls.ProductDetails();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productDetails1
            // 
            this.productDetails1.Location = new System.Drawing.Point(1, 74);
            this.productDetails1.Name = "productDetails1";
            this.productDetails1.Size = new System.Drawing.Size(643, 263);
            this.productDetails1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(235, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Details";
            // 
            // ProductDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductDetailsForm";
            this.Text = "ProductDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ProductDetails productDetails1;
        private System.Windows.Forms.Label label1;
    }
}