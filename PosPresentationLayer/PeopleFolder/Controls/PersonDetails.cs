using PosBusinessLayer;
using PosPresentationLayer.Properties;
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
    public partial class PersonDetails : UserControl
    {

        clsPeople Person = new clsPeople();
        public PersonDetails()
        {
            InitializeComponent();
            linkLabel1.Enabled = false; 
        }

        private bool _EnableUpdate = false;

        public bool EnableUpdate
        {
            get { return _EnableUpdate; }
            set
            {
                _EnableUpdate = value;
                linkLabel1.Enabled = _EnableUpdate;
            }
        }
        public void FillByPersonID(int ID)
        {
            Person = clsPeople.GetPersonByID(ID);

            if(Person != null)
            {
                LBpersonID.Text = Person.PersonID.ToString();
                LBfirstName.Text = Person.FirstName.ToString();
                LBsecondName.Text = Person.LastName.ToString();
                LBaddress.Text = Person.PersonAddress.ToString();
                LBdate.Text = Person.BirthDate.ToShortDateString();
                LBphone.Text = Person.Phones[0].PhoneNumber.ToString();

                if (Person.Phones.Count > 1)
                    LBphone2.Text = Person.Phones[1].PhoneNumber.ToString();
                else
                    LBphone2.Text = "N°2 Doesn't Exist";

                if (Person.Gender == "M")
                {
                    LBgender.Text = "Male";
                    pictureGender.Image = Resources.person_little_boy;
                    pictureTitle.Image = Resources.person_man;
                }
                else
                {
                    LBgender.Text = "Female";
                    pictureGender.Image = Resources.person_little_girl;
                    pictureTitle.Image = Resources.person_woman;
                }

                if (Person.PersonImage == "")
                    return;
                else
                {
                    pictureTitle.Load(Person.PersonImage);
                }

                EnableUpdate = true;

            }
            else
            {
                MessageBox.Show($"Person with {ID} Not Found !" , "Not Found" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdatePersonScreen fm = new AddUpdatePersonScreen(Person.PersonID);
             
            if(fm.ShowDialog() == DialogResult.OK)
            {
                FillByPersonID(Person.PersonID);
                EnableUpdate = false;
            }
        
        }
    }
}
