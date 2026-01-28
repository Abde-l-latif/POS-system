namespace PosPresentationLayer.UsersFolder
{
    partial class AddUser
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
            this.GROU = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBuserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBtitle = new System.Windows.Forms.Label();
            this.BTNSave = new System.Windows.Forms.Button();
            this.personDetailsWithFilter1 = new PosPresentationLayer.PeopleFolder.Controls.personDetailsWithFilter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.GROU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // GROU
            // 
            this.GROU.Controls.Add(this.pictureBox4);
            this.GROU.Controls.Add(this.textPassword);
            this.GROU.Controls.Add(this.textUsername);
            this.GROU.Controls.Add(this.comboBox1);
            this.GROU.Controls.Add(this.label2);
            this.GROU.Controls.Add(this.checkBox1);
            this.GROU.Controls.Add(this.pictureBox3);
            this.GROU.Controls.Add(this.label5);
            this.GROU.Controls.Add(this.pictureBox2);
            this.GROU.Controls.Add(this.label3);
            this.GROU.Controls.Add(this.pictureBox1);
            this.GROU.Controls.Add(this.LBuserID);
            this.GROU.Controls.Add(this.label1);
            this.GROU.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GROU.Location = new System.Drawing.Point(6, 403);
            this.GROU.Margin = new System.Windows.Forms.Padding(4);
            this.GROU.Name = "GROU";
            this.GROU.Padding = new System.Windows.Forms.Padding(4);
            this.GROU.Size = new System.Drawing.Size(719, 141);
            this.GROU.TabIndex = 0;
            this.GROU.TabStop = false;
            this.GROU.Text = "Fill New User Information";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PosPresentationLayer.Properties.Resources.role;
            this.pictureBox4.Location = new System.Drawing.Point(479, 28);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 21);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 50;
            this.pictureBox4.TabStop = false;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(141, 99);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(176, 23);
            this.textPassword.TabIndex = 49;
            this.textPassword.UseSystemPasswordChar = true;
            this.textPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textPassword_Validating);
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(141, 62);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(176, 23);
            this.textUsername.TabIndex = 48;
            this.textUsername.Validating += new System.ComponentModel.CancelEventHandler(this.textUsername_Validating);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(509, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 25);
            this.comboBox1.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(432, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Role :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(588, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 21);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "Is Active";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PosPresentationLayer.Properties.Resources.user;
            this.pictureBox3.Location = new System.Drawing.Point(110, 63);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 42;
            this.label5.Text = "Username :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PosPresentationLayer.Properties.Resources.passwordIcon;
            this.pictureBox2.Location = new System.Drawing.Point(110, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Password :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PosPresentationLayer.Properties.Resources.id;
            this.pictureBox1.Location = new System.Drawing.Point(110, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // LBuserID
            // 
            this.LBuserID.AutoSize = true;
            this.LBuserID.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBuserID.Location = new System.Drawing.Point(138, 33);
            this.LBuserID.Name = "LBuserID";
            this.LBuserID.Size = new System.Drawing.Size(20, 17);
            this.LBuserID.TabIndex = 37;
            this.LBuserID.Text = "??";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID :";
            // 
            // LBtitle
            // 
            this.LBtitle.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBtitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LBtitle.Location = new System.Drawing.Point(143, 11);
            this.LBtitle.Name = "LBtitle";
            this.LBtitle.Size = new System.Drawing.Size(433, 31);
            this.LBtitle.TabIndex = 5;
            this.LBtitle.Text = "Add User";
            this.LBtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTNSave
            // 
            this.BTNSave.BackColor = System.Drawing.Color.IndianRed;
            this.BTNSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNSave.FlatAppearance.BorderSize = 0;
            this.BTNSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.BTNSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNSave.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNSave.ForeColor = System.Drawing.Color.White;
            this.BTNSave.Location = new System.Drawing.Point(594, 551);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(132, 28);
            this.BTNSave.TabIndex = 8;
            this.BTNSave.Text = "Save";
            this.BTNSave.UseVisualStyleBackColor = false;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // personDetailsWithFilter1
            // 
            this.personDetailsWithFilter1.FilterField = true;
            this.personDetailsWithFilter1.Location = new System.Drawing.Point(-1, 50);
            this.personDetailsWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.personDetailsWithFilter1.Name = "personDetailsWithFilter1";
            this.personDetailsWithFilter1.Size = new System.Drawing.Size(735, 354);
            this.personDetailsWithFilter1.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 585);
            this.Controls.Add(this.BTNSave);
            this.Controls.Add(this.LBtitle);
            this.Controls.Add(this.personDetailsWithFilter1);
            this.Controls.Add(this.GROU);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.GROU.ResumeLayout(false);
            this.GROU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GROU;
        private PeopleFolder.Controls.personDetailsWithFilter personDetailsWithFilter1;
        private System.Windows.Forms.Label LBtitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBuserID;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}