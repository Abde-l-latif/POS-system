namespace PosPresentationLayer.CustomerFolder
{
    partial class CustomerDetailsForm
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
            this.customerDetailsControl1 = new PosPresentationLayer.CustomerFolder.Controls.CustomerDetailsControl();
            this.SuspendLayout();
            // 
            // LBtitle
            // 
            this.LBtitle.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBtitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LBtitle.Location = new System.Drawing.Point(82, 9);
            this.LBtitle.Name = "LBtitle";
            this.LBtitle.Size = new System.Drawing.Size(433, 31);
            this.LBtitle.TabIndex = 30;
            this.LBtitle.Text = "Customer Details";
            this.LBtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerDetailsControl1
            // 
            this.customerDetailsControl1.Location = new System.Drawing.Point(1, 46);
            this.customerDetailsControl1.Name = "customerDetailsControl1";
            this.customerDetailsControl1.Size = new System.Drawing.Size(634, 328);
            this.customerDetailsControl1.TabIndex = 31;
            // 
            // CustomerDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 373);
            this.Controls.Add(this.customerDetailsControl1);
            this.Controls.Add(this.LBtitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerDetailsForm";
            this.Text = "CustomerDetailsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LBtitle;
        private Controls.CustomerDetailsControl customerDetailsControl1;
    }
}