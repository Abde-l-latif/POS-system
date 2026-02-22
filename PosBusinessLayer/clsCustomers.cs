using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsCustomers : clsPeople
    {
        enum enMode { AddMode, UpdateMode }

        enMode _Mode = enMode.AddMode;

        public int CustomerID { get; private set; }

        public void SetPersonID(int id)
        {
            this.PersonID = id;
        }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public clsCustomers()
        {
            _Mode = enMode.AddMode;
        }

        public clsCustomers(int customerID, int PersonID, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt, string FirstName, string LastName, DateTime BirthDate,
            string PersonAddress, string PersonImage, string Gender, List<clsPhones> Phones)
        {
            _Mode = enMode.UpdateMode;
            this.CustomerID = customerID;
            this.PersonID = PersonID;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.PersonAddress = PersonAddress;
            this.PersonImage = PersonImage;
            this.Gender = Gender;
            this.Phones = Phones;
        }

        private bool _AddCustomer()
        {
            this.CustomerID = clsDataCustomers.InsertCustomers(this.PersonID, this.IsActive, DateTime.Now, DateTime.Now);
            return this.CustomerID != -1;
        }

        private bool _UpdateCustomer()
        {
            return clsDataCustomers.UpdateCustomers(this.CustomerID, this.PersonID, this.IsActive, DateTime.Now);
        }


        public bool isCustomerExist()
        {
            return clsDataCustomers.IsCustomerExist(this.CustomerID);
        }

        static public bool isCustomerExist(int ID)
        {
            return clsDataCustomers.IsCustomerExist(ID);
        }

        public bool isPersonAlreadyCustomer()
        {
            return clsDataCustomers.IsPersonAlreadyCustomer(this.PersonID);
        }

        static public bool isPersonAlreadyCustomer(int ID)
        {
            return clsDataCustomers.IsPersonAlreadyCustomer(ID);
        }

        static public int GetCustomerIDByFirstName(string FirstName)
        {
            return clsDataCustomers.GetCustomerIDByFirstName(FirstName);
        }

        public override bool Delete()
        {
            return clsDataCustomers.DeleteCustomers(this.CustomerID);
        }


        static public clsCustomers FindCustomerByID(int id)
        {
            int PersonID = -1;
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;
            string FirstName = "", LastName = "", PersonAddress = "", PersonImage = "";
            DateTime BirthDate = DateTime.Now;
            string Gender = "";
            List<clsPhones> Phones = new List<clsPhones>();

            if (clsDataCustomers.GetCustomersId(id, ref PersonID, ref IsActive, ref CreatedAt, ref UpdatedAt))
            {

                if (clsDataPeople.SelectPersonByID(PersonID, ref FirstName, ref LastName, ref BirthDate,
                ref PersonAddress, ref PersonImage, ref Gender))
                {
                    DataTable DT = clsPhones.GetPersonPhones(PersonID);

                    foreach (DataRow row in DT.Rows)
                    {
                        Phones.Add(new clsPhones((int)row["PhoneID"], (string)row["PhoneNumber"], (int)row["PersonID"]));
                    }

                }

                return new clsCustomers(id, PersonID, IsActive, CreatedAt, UpdatedAt, FirstName, LastName, BirthDate,
                PersonAddress, PersonImage, Gender, Phones);
            }
            else
                return null;
        }


        public override bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddCustomer())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdateCustomer();
            }

            return false;
        }
        static public DataTable GetAllCustomers()
        {
            return clsDataCustomers.GetAllCustomers();
        }
    }
}
