using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.PeopleFolder.Controls
{
    public partial class personDetailsWithFilter : UserControl
    {
        public personDetailsWithFilter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textFilter.Text))
            {
                MessageBox.Show("give the person id before Searching" , "Lack of Info" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            personDetails1.FillByPersonID(Convert.ToInt32(textFilter.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUpdatePersonScreen Fm = new AddUpdatePersonScreen();
            Fm.SelectPersonID += getPersonId;
            Fm.ShowDialog();
        }

        private void getPersonId(object sender , int id)
        {
            personDetails1.FillByPersonID(id);
        }
    }
}
