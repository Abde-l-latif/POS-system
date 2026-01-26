using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsPhones
    {
        enum enMode { addMode, updateMode }

        enMode _Mode;

        public int PhoneID { get; private set; }

        public string PhoneNumber { get; set; }

        public int PersonID { get; set; }

        public clsPhones()
        {
            _Mode = enMode.addMode;
        }

        public clsPhones(int PhoneID , string PhoneNumber , int PersonID)
        {
            _Mode = enMode.updateMode;
            this.PhoneID = PhoneID;
            this.PhoneNumber = PhoneNumber;
            this.PersonID = PersonID;
        }

        static public DataTable GetPersonPhones(int PersonID)
        {
            return clsDataPhones.SelectAllPersonPhones(PersonID);
        }

        private bool _AddPhone()
        {
            this.PhoneID = clsDataPhones.InsertPhone(this.PhoneNumber, this.PersonID);
            return this.PhoneID != -1;
        }

        public bool Delete()
        {
            return clsDataPhones.DeleteByPhoneID(this.PhoneID);
        }

        private bool _UpdatePhone()
        {
            return clsDataPhones.UpdatePhoneNumber(this.PhoneID , this.PhoneNumber);
        }

        public bool Save()
        {
            if (_Mode == enMode.addMode)
            {

                if( _AddPhone() )
                {
                    _Mode = enMode.updateMode;
                    return true;
                }
            }
            else if (_Mode == enMode.updateMode)
            {
                return _UpdatePhone();
            }

            return false;
        }

    }
}
