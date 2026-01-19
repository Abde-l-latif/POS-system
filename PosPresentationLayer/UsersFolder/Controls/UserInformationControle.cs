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
    public partial class UserInformationControle : UserControl
    {
        public UserInformationControle()
        {
            InitializeComponent();
        }

        public void loadDataByUserID(int ID)
        {
            clsUsers user = clsUsers.GetUserById(ID);

            if (user != null)
            {
                LBusername.Text = user.Username; 
                LBactive.Text = user.IsActive ? "Yes" : "No";
                LBcreatedAt.Text = user.CreatedAt.ToShortDateString();

            } else
                MessageBox.Show("User not found Something Went Wrong !" , "Not found" , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
