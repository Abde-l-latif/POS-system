namespace PosPresentationLayer.UsersFolder.Controls
{
    partial class UserDetails
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
            this.userInformationControle1 = new PosPresentationLayer.UsersFolder.Controls.UserInformationControle();
            this.personDetails1 = new PosPresentationLayer.PeopleFolder.PersonDetails();
            this.SuspendLayout();
            // 
            // userInformationControle1
            // 
            this.userInformationControle1.Location = new System.Drawing.Point(38, 231);
            this.userInformationControle1.Name = "userInformationControle1";
            this.userInformationControle1.Size = new System.Drawing.Size(559, 102);
            this.userInformationControle1.TabIndex = 0;
            // 
            // personDetails1
            // 
            this.personDetails1.EnableUpdate = false;
            this.personDetails1.Location = new System.Drawing.Point(3, 3);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(628, 232);
            this.personDetails1.TabIndex = 1;
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.personDetails1);
            this.Controls.Add(this.userInformationControle1);
            this.Name = "UserDetails";
            this.Size = new System.Drawing.Size(632, 339);

            this.ResumeLayout(false);

        }

        #endregion

        private UserInformationControle userInformationControle1;
        private PeopleFolder.PersonDetails personDetails1;
    }
}
