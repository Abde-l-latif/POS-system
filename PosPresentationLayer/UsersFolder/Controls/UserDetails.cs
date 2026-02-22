using PosBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.UsersFolder.Controls
{
    public partial class UserDetails : UserControl
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        public void LoadDataByUserID(int ID)
        {
            clsUsers user = clsUsers.GetUserById(ID);

            if (user != null)
            {
                userInformationControle1.loadDataByUserID(user.UserID);
                personDetails1.FillByPersonID(user.PersonID);
                personDetails1.EnableUpdate = false;
            }
            else
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
