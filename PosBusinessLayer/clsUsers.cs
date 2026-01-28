using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsUsers
    {

        enum enMode { AddMode , UpdateMode }

        private enMode _Mode = enMode.AddMode;

        public int UserID { get; private set; }

        public int PersonID { get; set; }


        public clsPeople Person;

        public int RoleID { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Username { get; set; }

        public string UserPassword { get; set; }


        public clsUsers()
        {
            _Mode = enMode.AddMode;
        }

        public clsUsers(int UserID, int PersonID, int RoleID , bool IsActive , DateTime CreatedAt , DateTime UpdatedAt , string Username , string UserPassword)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            Person = clsPeople.GetPersonByID(PersonID);
            this.RoleID = RoleID;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.Username = Username;
            this.UserPassword = UserPassword;

            _Mode = enMode.UpdateMode;
        }

        static public clsUsers LoginAccount(string Username , string UserPassword)
        {
            int UserID = -1, PersonID = -1, RoleID = -1;
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now , UpdatedAt = DateTime.Now ;

            if (clsDataUsers.FindByPasswordAndUsername(ref UserID, ref PersonID, ref RoleID, ref IsActive, ref CreatedAt, ref UpdatedAt, Username, UserPassword))
            {
                return new clsUsers(UserID, PersonID, RoleID, IsActive, CreatedAt, UpdatedAt, Username, UserPassword);
            }
            else
                return null;
        }

        static public clsUsers GetUserById(int UserID)
        {
            int PersonID = -1, RoleID = -1;
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;
            string Username = "", UserPassword = ""; 

            if (clsDataUsers.FindByUserID(UserID, ref PersonID, ref RoleID, ref IsActive, ref CreatedAt, ref UpdatedAt, ref Username, ref UserPassword))
            {
                return new clsUsers(UserID, PersonID, RoleID, IsActive, CreatedAt, UpdatedAt, Username, UserPassword);
            }
            else
                return null;
        }

        private bool _UpdateUser()
        {
            return clsDataUsers.UpdateUserInformation(this.UserID, this.RoleID, this.IsActive, this.Username, this.UserPassword);
        }

        private bool _AddUser()
        {
            this.UserID = clsDataUsers.InsertUser(this.PersonID , this.RoleID , this.IsActive, this.Username, this.UserPassword);
            return this.UserID != -1;
        }

        public bool Save()
        {
            if (_Mode == enMode.UpdateMode)
            {
                return _UpdateUser();
            }
            else if(_Mode == enMode.AddMode)
                return _AddUser();

            return false;
        }
    }
}
