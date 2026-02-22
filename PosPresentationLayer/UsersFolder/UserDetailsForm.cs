using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.UsersFolder
{
    public partial class UserDetailsForm : Form
    {
        public UserDetailsForm(int UserID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userDetails1.LoadDataByUserID(UserID);
        }
    }
}
