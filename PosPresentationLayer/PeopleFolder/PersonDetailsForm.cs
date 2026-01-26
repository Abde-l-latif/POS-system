using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.PeopleFolder
{
    public partial class PersonDetailsForm : Form
    {
        public PersonDetailsForm(int personID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            personDetails1.FillByPersonID(personID);
        }
    }
}
