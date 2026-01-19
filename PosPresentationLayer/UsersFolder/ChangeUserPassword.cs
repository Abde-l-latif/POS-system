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
    public partial class ChangeUserPassword : Form
    {
        public ChangeUserPassword()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userInformationControle1.loadDataByUserID(clsGlobal.User.UserID);
        }
    }
}
