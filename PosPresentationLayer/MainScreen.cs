using PosPresentationLayer.utilitiesFolder;
using System;
using System.Windows.Forms;
using PosPresentationLayer.UsersFolder;
using PosPresentationLayer.PeopleFolder;

namespace PosPresentationLayer
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            menuStrip1.Renderer = new CustomMenuRenderer();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserPassword fm = new ChangeUserPassword();
            fm.ShowDialog();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdatePersonScreen fm = new AddUpdatePersonScreen();
            fm.ShowDialog();
        }

        private void managePeopleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople fm = new ManagePeople();
            fm.ShowDialog();
        }

        private void findPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindPerson fm = new FindPerson();
            fm.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser fm = new AddUser();
            fm.ShowDialog();
        }

        private void manageUsersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsersForm fm = new ManageUsersForm();
            fm.ShowDialog();
        }
    }
}
