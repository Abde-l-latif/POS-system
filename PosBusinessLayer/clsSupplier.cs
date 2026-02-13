using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsSupplier : clsPeople
    {
        enum enMode { AddMode, UpdateMode }

        enMode _Mode = enMode.AddMode;

        public int SupplierID { get; private set; }

        public void SetPersonID(int id)
        {
            this.PersonID = id;
        }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public clsSupplier()
        {
            _Mode = enMode.AddMode;
        }

        public clsSupplier(int supplierID, int PersonID, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt, string FirstName, string LastName, DateTime BirthDate,
            string PersonAddress, string PersonImage, string Gender, List<clsPhones> Phones)
        {
            _Mode = enMode.UpdateMode;
            this.SupplierID = supplierID;
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

        private bool _AddSupplier()
        {
            this.SupplierID = clsDataSuppliers.InsertSuppliers(this.PersonID, this.IsActive, DateTime.Now, DateTime.Now);
            return this.SupplierID != -1;
        }

        private bool _UpdateSupplier()
        {
            return clsDataSuppliers.UpdateSuppliers(this.SupplierID, this.PersonID, this.IsActive, DateTime.Now);
        }

        public bool isSupplierExist()
        {
            return clsDataSuppliers.IsSupplierExist(this.SupplierID);
        }

        static public bool isSupplierExist(int ID)
        {
            return clsDataSuppliers.IsSupplierExist(ID);
        }

        public bool isPersonAlreadySupplier()
        {
            return clsDataSuppliers.IsPersonAlreadySupplier(this.PersonID);
        }

        static public bool isPersonAlreadySupplier(int ID)
        {
            return clsDataSuppliers.IsPersonAlreadySupplier(ID);
        }

        static public int GetSupplierIDByFirstName(string FirstName)
        {
            return clsDataSuppliers.GetSupplierIDByFirstName(FirstName);
        }

        public static DataTable GetAllSuppliers()
        {
            return clsDataSuppliers.GetAllSuppliers();
        }

        public bool Delete()
        {
            return clsDataSuppliers.DeleteSuppliers(this.SupplierID);
        }

        static public bool Delete(int id)
        {
            return clsDataSuppliers.DeleteSuppliers(id);
        }

        static public clsSupplier FindSupplierByID(int id)
        {
            int PersonID = -1;
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now , UpdatedAt = DateTime.Now;
            string FirstName = "", LastName = "", PersonAddress = "", PersonImage = "";
            DateTime BirthDate = DateTime.Now;
            string Gender = "";
            List<clsPhones> Phones = new List<clsPhones>();

            if (clsDataSuppliers.GetSuppliersById(id, ref PersonID , ref IsActive, ref CreatedAt, ref UpdatedAt))
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

                return new clsSupplier(id, PersonID, IsActive, CreatedAt, UpdatedAt, FirstName, LastName, BirthDate,
                PersonAddress, PersonImage, Gender, Phones);
            }
            else
                return null; 
        }


        public override bool Save()
        {
            if(_Mode == enMode.AddMode)
            {
                if(_AddSupplier())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
            }
            else if(_Mode == enMode.UpdateMode)
            {
                return _UpdateSupplier();
            }

            return false;
        }
    }
}
