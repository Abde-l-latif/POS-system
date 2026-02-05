namespace PosPresentationLayer.ProductFolder.Controls
{
    partial class ProductBoxControl
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
            this.LbProductName = new System.Windows.Forms.Label();
            this.LBPrice = new System.Windows.Forms.Label();
            this.ProductPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPic)).BeginInit();
            this.SuspendLayout();
            // 
            // LbProductName
            // 
            this.LbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbProductName.Location = new System.Drawing.Point(5, 110);
            this.LbProductName.Name = "LbProductName";
            this.LbProductName.Size = new System.Drawing.Size(162, 30);
            this.LbProductName.TabIndex = 0;
            this.LbProductName.Text = "product Name";
            this.LbProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBPrice
            // 
            this.LBPrice.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBPrice.ForeColor = System.Drawing.Color.IndianRed;
            this.LBPrice.Location = new System.Drawing.Point(33, 145);
            this.LBPrice.Name = "LBPrice";
            this.LBPrice.Size = new System.Drawing.Size(100, 30);
            this.LBPrice.TabIndex = 1;
            this.LBPrice.Text = "05.23";
            this.LBPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductPic
            // 
            this.ProductPic.Image = global::PosPresentationLayer.Properties.Resources.box;
            this.ProductPic.Location = new System.Drawing.Point(26, 9);
            this.ProductPic.Name = "ProductPic";
            this.ProductPic.Size = new System.Drawing.Size(119, 101);
            this.ProductPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ProductPic.TabIndex = 2;
            this.ProductPic.TabStop = false;
            // 
            // ProductBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.Controls.Add(this.ProductPic);
            this.Controls.Add(this.LBPrice);
            this.Controls.Add(this.LbProductName);
            this.Name = "ProductBoxControl";
            this.Size = new System.Drawing.Size(173, 175);
            this.Load += new System.EventHandler(this.ProductBoxControl_Load);
            this.DoubleClick += new System.EventHandler(this.ProductBoxControl_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.ProductPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbProductName;
        private System.Windows.Forms.Label LBPrice;
        private System.Windows.Forms.PictureBox ProductPic;
    }
}
