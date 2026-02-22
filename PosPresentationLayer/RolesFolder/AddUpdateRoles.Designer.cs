namespace PosPresentationLayer.RolesFolder
{
    partial class AddUpdateRoles
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
            this.pictureTitle = new System.Windows.Forms.PictureBox();
            this.LbTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textRoleName = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LBRoleID = new System.Windows.Forms.Label();
            this.BTNSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureTitle
            // 
            this.pictureTitle.Image = global::PosPresentationLayer.Properties.Resources.role_addTitle;
            this.pictureTitle.Location = new System.Drawing.Point(153, 12);
            this.pictureTitle.Name = "pictureTitle";
            this.pictureTitle.Size = new System.Drawing.Size(93, 82);
            this.pictureTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTitle.TabIndex = 0;
            this.pictureTitle.TabStop = false;
            // 
            // LbTitle
            // 
            this.LbTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LbTitle.Location = new System.Drawing.Point(109, 97);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(180, 29);
            this.LbTitle.TabIndex = 1;
            this.LbTitle.Text = "Add New Role";
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(17, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Role Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(12, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Permissions :";
            // 
            // textRoleName
            // 
            this.textRoleName.Location = new System.Drawing.Point(114, 182);
            this.textRoleName.Name = "textRoleName";
            this.textRoleName.Size = new System.Drawing.Size(211, 20);
            this.textRoleName.TabIndex = 4;
            this.textRoleName.Validating += new System.ComponentModel.CancelEventHandler(this.textRoleName_Validating);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(114, 224);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(210, 94);
            this.checkedListBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(43, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Role ID :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PosPresentationLayer.Properties.Resources.id;
            this.pictureBox2.Location = new System.Drawing.Point(114, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // LBRoleID
            // 
            this.LBRoleID.AutoSize = true;
            this.LBRoleID.Location = new System.Drawing.Point(142, 148);
            this.LBRoleID.Name = "LBRoleID";
            this.LBRoleID.Size = new System.Drawing.Size(19, 13);
            this.LBRoleID.TabIndex = 19;
            this.LBRoleID.Text = "??";
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
            this.BTNSave.Location = new System.Drawing.Point(242, 343);
            this.BTNSave.Name = "BTNSave";
            this.BTNSave.Size = new System.Drawing.Size(132, 28);
            this.BTNSave.TabIndex = 21;
            this.BTNSave.Text = "Save";
            this.BTNSave.UseVisualStyleBackColor = false;
            this.BTNSave.Click += new System.EventHandler(this.BTNSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddUpdateRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 379);
            this.Controls.Add(this.BTNSave);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LBRoleID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.textRoleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.pictureTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddUpdateRoles";
            this.Text = "AddUpdateRoles";
            this.Load += new System.EventHandler(this.AddUpdateRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureTitle;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRoleName;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LBRoleID;
        private System.Windows.Forms.Button BTNSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}