namespace PosPresentationLayer.UsersFolder
{
    partial class FindUserForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBtitle = new System.Windows.Forms.Label();
            this.userDetailsWithFilter1 = new PosPresentationLayer.UsersFolder.Controls.UserDetailsWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PosPresentationLayer.Properties.Resources.supp;
            this.pictureBox1.Location = new System.Drawing.Point(241, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // LBtitle
            // 
            this.LBtitle.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBtitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LBtitle.Location = new System.Drawing.Point(91, 133);
            this.LBtitle.Name = "LBtitle";
            this.LBtitle.Size = new System.Drawing.Size(433, 31);
            this.LBtitle.TabIndex = 31;
            this.LBtitle.Text = "Find User";
            this.LBtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userDetailsWithFilter1
            // 
            this.userDetailsWithFilter1.Location = new System.Drawing.Point(7, 172);
            this.userDetailsWithFilter1.Name = "userDetailsWithFilter1";
            this.userDetailsWithFilter1.Size = new System.Drawing.Size(640, 398);
            this.userDetailsWithFilter1.TabIndex = 33;
            // 
            // FindUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 569);
            this.Controls.Add(this.userDetailsWithFilter1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LBtitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindUserForm";
            this.Text = "FindUserForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBtitle;
        private Controls.UserDetailsWithFilter userDetailsWithFilter1;
    }
}