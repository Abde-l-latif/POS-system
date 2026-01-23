using PosBusinessLayer;
using PosPresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosPresentationLayer.PeopleFolder
{
    public partial class AddUpdatePersonScreen : Form
    {
        clsPeople person;

        char _Gender;

        string _ImagePath = "";

        bool _MarkDeleteImage = false; 

        public AddUpdatePersonScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            InitializeGender();
            InitializeProfile();
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-100);
        }

        private void InitializeGender()
        {
            if(radioMale.Checked)
            {
                _Gender = 'M';
            }
            else 
            {
                _Gender = 'F';
            }
        }

        private void InitializeProfile()
        {
            if(_Gender == 'M')
            {
                pictureTitle.Image = Resources.person_man;
            }
            else
                pictureTitle.Image = Resources.person_woman;
        }


        private void BTNSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("uncomplete data you need to fill the required fields !", "Uncompleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            person = new clsPeople();

            person.FirstName = textFirstName.Text;
            person.LastName = textLastName.Text;
            person.PersonAddress = textAddress.Text;
            person.BirthDate = Convert.ToDateTime(dateTimePicker1.Text);
            person.Gender = _Gender;

            clsPhones Phone = new clsPhones();
            Phone.PhoneNumber = textPhone.Text;
            person.Phones.Add(Phone);

            if (!string.IsNullOrEmpty(textPhone2.Text))
            {
                clsPhones Phone2 = new clsPhones();
                Phone2.PhoneNumber = textPhone2.Text;
                person.Phones.Add(Phone2);
            }


            _DeleteFromFolderIfIsMarked();
            person.PersonImage = _ImagePath;

            if(person.Save())
            {
                LBpersonID.Text = person.PersonID.ToString();
                MessageBox.Show("Operation Done successfully !", "succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
                this.FormClosing -= AddUpdatePersonScreen_FormClosing;

                this.Close();
                return;
            }
            else
                MessageBox.Show("Operation Failed !", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null || !rb.Checked)
                return;

            if (rb == radioMale)
            {
                _Gender = 'M';
                pictureTitle.Image = Resources.person_man;
            }
            else if (rb == radioFemale)
            {
                _Gender = 'F';
                pictureTitle.Image = Resources.person_woman;
            }
        }

        private void _DeleteFromFolderIfIsMarked()
        {
            if (_MarkDeleteImage)
            {

                if (File.Exists(_ImagePath))
                {
                    File.Delete(_ImagePath);
                }

                _MarkDeleteImage = false;
                _ImagePath = "";

            }
        }

        private string _SaveImageToFolder(string OriginalFile)
        {
            _DeleteFromFolderIfIsMarked();

            string imagesFolder = Path.Combine(
                Application.StartupPath,
                "POSimageFolder"
            );

            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            string extension = Path.GetExtension(OriginalFile);

            string newFileName = $"{Guid.NewGuid()}{extension}";

            string destinationPath = Path.Combine(imagesFolder, newFileName);

            File.Copy(OriginalFile, destinationPath, true);

            _ImagePath = destinationPath;

            return destinationPath;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select an Image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = ofd.FileName;
                string SavedPath = _SaveImageToFolder(ImagePath);

                using (var img = Image.FromFile(SavedPath))
                {
                    pictureTitle.Image = new Bitmap(img);
                }

                linkLabel2.Visible = true;
                linkLabel2.Enabled = true;

                linkLabel1.Visible = false;
                linkLabel1.Enabled = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InitializeProfile();

            _MarkDeleteImage = true;

            linkLabel1.Visible = true;
            linkLabel1.Enabled = true;

            linkLabel2.Visible = false;
            linkLabel2.Enabled = false;
        }


        // Validation 
        private void textFirstName_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(textFirstName.Text))
            {
                errorProvider1.SetError(textFirstName, "this field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textFirstName, "");
                e.Cancel = false;
            }
        }

        private void textLastName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textLastName.Text))
            {
                errorProvider1.SetError(textLastName, "this field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textLastName, "");
                e.Cancel = false;
            }
        }

        private void textPhone_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textPhone.Text) || textPhone.Text.Length != 10)
            {
                errorProvider1.SetError(textPhone, "this field is required , and it has to be 10 numbers ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textPhone, "");
                e.Cancel = false;
            }
        }

        private void textAddress_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textAddress.Text))
            {
                errorProvider1.SetError(textAddress, "this field is required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textAddress, "");
                e.Cancel = false;
            }
        }

        private void textPhone2_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(textPhone2.Text) && textPhone2.Text.Length != 10)
            {
                errorProvider1.SetError(textPhone2, "it has to be 10 numbers");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textPhone2, "");
                e.Cancel = false;
            }
        }

        private void AddUpdatePersonScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!String.IsNullOrEmpty(_ImagePath))
            {
                _MarkDeleteImage = true; 
                _DeleteFromFolderIfIsMarked();
            }
        }

    }
}
