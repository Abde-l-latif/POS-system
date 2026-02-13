namespace PosPresentationLayer.ProductFolder.Controls
{
    partial class ProductCard
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
            this.pictureProduct = new System.Windows.Forms.PictureBox();
            this.LbName = new System.Windows.Forms.Label();
            this.LbQuantity = new System.Windows.Forms.Label();
            this.LbPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureProduct
            // 
            this.pictureProduct.Location = new System.Drawing.Point(3, 6);
            this.pictureProduct.Name = "pictureProduct";
            this.pictureProduct.Size = new System.Drawing.Size(48, 45);
            this.pictureProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureProduct.TabIndex = 0;
            this.pictureProduct.TabStop = false;
            // 
            // LbName
            // 
            this.LbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LbName.Location = new System.Drawing.Point(57, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(109, 45);
            this.LbName.TabIndex = 1;
            this.LbName.Text = "???";
            this.LbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbQuantity
            // 
            this.LbQuantity.AutoSize = true;
            this.LbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbQuantity.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LbQuantity.Location = new System.Drawing.Point(174, 22);
            this.LbQuantity.Name = "LbQuantity";
            this.LbQuantity.Size = new System.Drawing.Size(27, 13);
            this.LbQuantity.TabIndex = 2;
            this.LbQuantity.Text = "x??";
            // 
            // LbPrice
            // 
            this.LbPrice.AutoSize = true;
            this.LbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbPrice.ForeColor = System.Drawing.Color.IndianRed;
            this.LbPrice.Location = new System.Drawing.Point(219, 22);
            this.LbPrice.Name = "LbPrice";
            this.LbPrice.Size = new System.Drawing.Size(54, 13);
            this.LbPrice.TabIndex = 3;
            this.LbPrice.Text = "0.00 DH";
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.Controls.Add(this.LbPrice);
            this.Controls.Add(this.LbQuantity);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.pictureProduct);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(297, 57);
            ((System.ComponentModel.ISupportInitialize)(this.pictureProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureProduct;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Label LbQuantity;
        private System.Windows.Forms.Label LbPrice;
    }
}
