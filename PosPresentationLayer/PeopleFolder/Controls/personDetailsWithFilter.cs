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

namespace PosPresentationLayer.PeopleFolder.Controls
{
    public partial class personDetailsWithFilter : UserControl
    {

        public event EventHandler<int> PersonSelected;

        public personDetailsWithFilter()
        {
            InitializeComponent();
        }

        public PersonDetails personDetails
        {
            get
            {
                return personDetails1;
            }
        }

        public int PersonID
        {
            set 
            {
                int PersonID = Convert.ToInt32(value);
                personDetails1.FillByPersonID(PersonID);   
            }
        }

        private string _text = string.Empty;

        private bool _FilterField = true;

        public bool FilterField
        {
            get
            {
                return _FilterField;
            }
            set
            {
                _FilterField = value;
                groupBox1.Enabled = _FilterField;
            }
        }

        public string TextField
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                textFilter.Text = _text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textFilter.Text))
            {
                MessageBox.Show("give the person id before Searching" , "Lack of Info" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsPeople.IsPersonExist(Convert.ToInt32(textFilter.Text)))
            {

                personDetails1.FillByPersonID(Convert.ToInt32(textFilter.Text));
                FilterField = false;
                personDetails1.EnableUpdate = true;
                PersonSelected?.Invoke(this, Convert.ToInt32(textFilter.Text));

            }
            else
                MessageBox.Show("Person not found make sure you wrote the correct id ", "Not Found" , MessageBoxButtons.OK , MessageBoxIcon.Error);
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
            personDetails1.EnableUpdate = true;
            PersonSelected?.Invoke(this, Convert.ToInt32(textFilter.Text));
            FilterField = false;
        }
    }
}
