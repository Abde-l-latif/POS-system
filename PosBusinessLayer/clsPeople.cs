using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace PosBusinessLayer
{
    public class clsPeople
    {
        enum enMode { addMode , updateMode }

        private enMode _Mode;

        public int PersonID { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PersonAddress { get; set; }

        public string PersonImage { get; set; }

        public string Gender { get; set; }

        public List<clsPhones> Phones { get; set; }

        public clsPeople()
        {
            _Mode = enMode.addMode;
            Phones = new List<clsPhones>();
        }

        public clsPeople(int PersonID, string FirstName, string LastName, DateTime BirthDate,
            string PersonAddress, string PersonImage, string Gender , List<clsPhones> Phones)
        {
            _Mode = enMode.updateMode;
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.PersonAddress = PersonAddress;
            this.PersonImage = PersonImage;
            this.Gender = Gender;
            this.Phones = Phones;

        }

        private bool _AddPerson()
        {
            this.PersonID = clsDataPeople.InsertPerson(this.FirstName, this.LastName, this.BirthDate, this.PersonAddress, this.PersonImage, this.Gender);
            return this.PersonID != -1; 
        }

        private bool _UpdatePerson()
        {
            return clsDataPeople.UpdatePerson(this.PersonID, this.FirstName, this.LastName, this.BirthDate, this.PersonAddress, this.PersonImage, this.Gender);
        }

        static public clsPeople GetPersonByID(int ID)
        {

            string FirstName = "", LastName = "" , PersonAddress = "" , PersonImage = "";
            DateTime BirthDate = DateTime.Now;
            string Gender = "";
            List<clsPhones> Phones = new List<clsPhones>();


            if (clsDataPeople.SelectPersonByID(ID, ref FirstName, ref LastName, ref BirthDate,
            ref PersonAddress, ref PersonImage, ref Gender))
            {
                DataTable DT = clsPhones.GetPersonPhones(ID); 

                foreach(DataRow row in DT.Rows)
                {
                    Phones.Add(new clsPhones((int)row["PhoneID"], (string)row["PhoneNumber"], (int)row["PersonID"]));
                }

                return new clsPeople(ID, FirstName, LastName, BirthDate,
                PersonAddress, PersonImage, Gender, Phones);

            }
            else
                return null;
        }


        static public DataTable GetPeopleList()
        {
            return clsDataPeople.SelectAllPeopleData();
        }

        public bool Save()
        {
    
            if (_Mode == enMode.addMode)
            {
                using (var scope = new TransactionScope())
                {
                    if (_AddPerson())
                    {
                        foreach (var phone in Phones)
                        {
                            phone.PersonID = PersonID;
                            if (!phone.Save())
                                return false;
                        }
                    }
                    else
                        return false; 

                    scope.Complete();
                    _Mode = enMode.updateMode;
                    return true;
                }
               
     
            }
            else if(_Mode == enMode.updateMode)
            {
                using (var scope = new TransactionScope())
                {
                    if (_UpdatePerson())
                    {
                        foreach (var phone in Phones)
                        {
                            if (!phone.Save())
                                return false;
                        }
                    }
                    else
                        return false;

                    scope.Complete();
                    return true;
                }
            }


                return false; 
        }

    }
}
