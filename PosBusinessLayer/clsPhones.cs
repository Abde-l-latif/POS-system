using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private bool _AddPhone()
        {
            this.PhoneID = clsDataPhones.InsertPhone(this.PhoneNumber, this.PersonID);
            return this.PhoneID != -1;
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


            return false;
        }

    }
}
