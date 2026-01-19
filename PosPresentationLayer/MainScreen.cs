using PosPresentationLayer.utilitiesFolder;
using System;
using System.Windows.Forms;
using PosPresentationLayer.UsersFolder;

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

     
    }
}
