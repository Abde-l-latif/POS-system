namespace PosPresentationLayer.UsersFolder.Controls
{
    partial class ChangePasswordContole
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTNchangePass = new System.Windows.Forms.Button();
            this.TBconfirmPass = new System.Windows.Forms.TextBox();
            this.TBnewPass = new System.Windows.Forms.TextBox();
            this.TBcurrentPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNchangePass);
            this.groupBox1.Controls.Add(this.TBconfirmPass);
            this.groupBox1.Controls.Add(this.TBnewPass);
            this.groupBox1.Controls.Add(this.TBcurrentPass);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change password";
            // 
            // BTNchangePass
            // 
            this.BTNchangePass.BackColor = System.Drawing.Color.IndianRed;
            this.BTNchangePass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNchangePass.FlatAppearance.BorderSize = 0;
            this.BTNchangePass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.BTNchangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNchangePass.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNchangePass.ForeColor = System.Drawing.Color.White;
            this.BTNchangePass.Location = new System.Drawing.Point(414, 129);
            this.BTNchangePass.Name = "BTNchangePass";
            this.BTNchangePass.Size = new System.Drawing.Size(132, 28);
            this.BTNchangePass.TabIndex = 17;
            this.BTNchangePass.Text = "Change password";
            this.BTNchangePass.UseVisualStyleBackColor = false;
            this.BTNchangePass.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBconfirmPass
            // 
            this.TBconfirmPass.Location = new System.Drawing.Point(174, 90);
            this.TBconfirmPass.Name = "TBconfirmPass";
            this.TBconfirmPass.Size = new System.Drawing.Size(178, 20);
            this.TBconfirmPass.TabIndex = 16;
            this.TBconfirmPass.UseSystemPasswordChar = true;
            this.TBconfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.TBconfirmPass_Validating);
            // 
            // TBnewPass
            // 
            this.TBnewPass.Location = new System.Drawing.Point(174, 57);
            this.TBnewPass.Name = "TBnewPass";
            this.TBnewPass.Size = new System.Drawing.Size(178, 20);
            this.TBnewPass.TabIndex = 15;
            this.TBnewPass.UseSystemPasswordChar = true;
            this.TBnewPass.Validating += new System.ComponentModel.CancelEventHandler(this.TBnewPass_Validating);
            // 
            // TBcurrentPass
            // 
            this.TBcurrentPass.Location = new System.Drawing.Point(174, 25);
            this.TBcurrentPass.Name = "TBcurrentPass";
            this.TBcurrentPass.Size = new System.Drawing.Size(178, 20);
            this.TBcurrentPass.TabIndex = 14;
            this.TBcurrentPass.UseSystemPasswordChar = true;
            this.TBcurrentPass.Validating += new System.ComponentModel.CancelEventHandler(this.TBcurrentPass_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(26, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(43, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Password";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PosPresentationLayer.Properties.Resources.passwordIcon;
            this.pictureBox2.Location = new System.Drawing.Point(143, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PosPresentationLayer.Properties.Resources.passwordIcon;
            this.pictureBox1.Location = new System.Drawing.Point(143, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PosPresentationLayer.Properties.Resources.passwordIcon;
            this.pictureBox3.Location = new System.Drawing.Point(143, 24);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // ChangePasswordContole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ChangePasswordContole";
            this.Size = new System.Drawing.Size(558, 169);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBconfirmPass;
        private System.Windows.Forms.TextBox TBnewPass;
        private System.Windows.Forms.TextBox TBcurrentPass;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button BTNchangePass;
    }
}
