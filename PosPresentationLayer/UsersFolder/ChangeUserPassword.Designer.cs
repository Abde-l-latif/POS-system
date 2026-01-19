namespace PosPresentationLayer.UsersFolder
{
    partial class ChangeUserPassword
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.changePasswordContole1 = new PosPresentationLayer.UsersFolder.Controls.ChangePasswordContole();
            this.userInformationControle1 = new PosPresentationLayer.UsersFolder.Controls.UserInformationControle();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LBtitle
            // 
            this.LBtitle.AutoSize = true;
            this.LBtitle.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBtitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LBtitle.Location = new System.Drawing.Point(208, 99);
            this.LBtitle.Name = "LBtitle";
            this.LBtitle.Size = new System.Drawing.Size(249, 26);
            this.LBtitle.TabIndex = 1;
            this.LBtitle.Text = "Change Password Screen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PosPresentationLayer.Properties.Resources.changePasswordTitleIcon;
            this.pictureBox1.Location = new System.Drawing.Point(281, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // changePasswordContole1
            // 
            this.changePasswordContole1.Location = new System.Drawing.Point(3, 251);
            this.changePasswordContole1.Margin = new System.Windows.Forms.Padding(4);
            this.changePasswordContole1.Name = "changePasswordContole1";
            this.changePasswordContole1.Size = new System.Drawing.Size(656, 208);
            this.changePasswordContole1.TabIndex = 0;
            // 
            // userInformationControle1
            // 
            this.userInformationControle1.Location = new System.Drawing.Point(3, 125);
            this.userInformationControle1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.userInformationControle1.Name = "userInformationControle1";
            this.userInformationControle1.Size = new System.Drawing.Size(656, 127);
            this.userInformationControle1.TabIndex = 3;
            // 
            // ChangeUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 464);
            this.Controls.Add(this.userInformationControle1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LBtitle);
            this.Controls.Add(this.changePasswordContole1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangeUserPassword";
            this.Text = "ChangeUserPassword";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ChangePasswordContole changePasswordContole1;
        private System.Windows.Forms.Label LBtitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.UserInformationControle userInformationControle1;
    }
}