namespace PosPresentationLayer.ProductFolder
{
    partial class FindProductForm
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
            this.productDetailsWithFilter1 = new PosPresentationLayer.ProductFolder.Controls.ProductDetailsWithFilter();
            this.LbTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // productDetailsWithFilter1
            // 
            this.productDetailsWithFilter1.Location = new System.Drawing.Point(1, 57);
            this.productDetailsWithFilter1.Name = "productDetailsWithFilter1";
            this.productDetailsWithFilter1.Size = new System.Drawing.Size(652, 322);
            this.productDetailsWithFilter1.TabIndex = 0;
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LbTitle.Location = new System.Drawing.Point(250, 18);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(144, 26);
            this.LbTitle.TabIndex = 2;
            this.LbTitle.Text = "Find Products";
            // 
            // FindProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 380);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.productDetailsWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindProductForm";
            this.Text = "FindProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ProductDetailsWithFilter productDetailsWithFilter1;
        private System.Windows.Forms.Label LbTitle;
    }
}