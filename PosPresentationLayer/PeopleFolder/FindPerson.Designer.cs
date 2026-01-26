namespace PosPresentationLayer.PeopleFolder
{
    partial class FindPerson
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
            this.personDetailsWithFilter1 = new PosPresentationLayer.PeopleFolder.Controls.personDetailsWithFilter();
            this.LBtitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // personDetailsWithFilter1
            // 
            this.personDetailsWithFilter1.Location = new System.Drawing.Point(1, 38);
            this.personDetailsWithFilter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.personDetailsWithFilter1.Name = "personDetailsWithFilter1";
            this.personDetailsWithFilter1.Size = new System.Drawing.Size(729, 355);
            this.personDetailsWithFilter1.TabIndex = 0;
            // 
            // LBtitle
            // 
            this.LBtitle.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBtitle.ForeColor = System.Drawing.Color.IndianRed;
            this.LBtitle.Location = new System.Drawing.Point(143, 9);
            this.LBtitle.Name = "LBtitle";
            this.LBtitle.Size = new System.Drawing.Size(433, 31);
            this.LBtitle.TabIndex = 4;
            this.LBtitle.Text = "Find Person";
            this.LBtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 394);
            this.Controls.Add(this.LBtitle);
            this.Controls.Add(this.personDetailsWithFilter1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FindPerson";
            this.Text = "FindPerson";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.personDetailsWithFilter personDetailsWithFilter1;
        private System.Windows.Forms.Label LBtitle;
    }
}