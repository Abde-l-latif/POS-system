using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public char Gender { get; set; }

        public List<clsPhones> Phones { get; set; }

        public clsPeople()
        {
            _Mode = enMode.addMode;
            Phones = new List<clsPhones>();
        }

        private bool _AddPerson()
        {
            this.PersonID = clsDataPeople.InsertPerson(this.FirstName, this.LastName, this.BirthDate, this.PersonAddress, this.PersonImage, this.Gender);
            return this.PersonID != -1; 
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


            return false; 
        }

    }
}
