using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsUsers
    {
        enum enRoles { Admin = 1, Manager = 2, Cashier = 3 }

        enum enMode { AddMode, UpdateMode }


        private enMode _Mode = enMode.AddMode;

        public int UserID { get; private set; }

        public int PersonID { get; set; }


        public clsPeople Person;

        public int RoleID { get; set; }

        public clsRoles Role;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string Username { get; set; }

        public string UserPassword { get; set; }

        public long? CurrentPermissions { get; set; }


        public clsUsers()
        {
            _Mode = enMode.AddMode;
        }

        public clsUsers(int UserID, int PersonID, int RoleID, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt, string Username, string UserPassword
            , long? CurrentPermissions)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            Person = clsPeople.GetPersonByID(PersonID);
            this.RoleID = RoleID;
            Role = clsRoles.GetRoleByID(RoleID);
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.Username = Username;
            this.UserPassword = UserPassword;
            this.CurrentPermissions = CurrentPermissions;

            _Mode = enMode.UpdateMode;
        }

        static public clsUsers LoginAccount(string Username, string UserPassword)
        {
            int UserID = -1, PersonID = -1, RoleID = -1;
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;
            long? CurrentPermissions = null;

            if (clsDataUsers.FindByPasswordAndUsername(ref UserID, ref PersonID, ref RoleID, ref IsActive, ref CreatedAt, ref UpdatedAt, Username, UserPassword, ref CurrentPermissions))
            {
                return new clsUsers(UserID, PersonID, RoleID, IsActive, CreatedAt, UpdatedAt, Username, UserPassword, CurrentPermissions);
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
            long? CurrentPermissions = null;

            if (clsDataUsers.FindByUserID(UserID, ref PersonID, ref RoleID, ref IsActive, ref CreatedAt, ref UpdatedAt, ref Username, ref UserPassword, ref CurrentPermissions))
            {
                return new clsUsers(UserID, PersonID, RoleID, IsActive, CreatedAt, UpdatedAt, Username, UserPassword, CurrentPermissions);
            }
            else
                return null;
        }

        static public bool IsPersonAlreadyUser(int PersonID)
        {
            return clsDataUsers.IsPersonAlreadyUser(PersonID);
        }

        static public DataTable GetAllUsers()
        {
            return clsDataUsers.GetAllUsersInformation();
        }

        private bool _UpdateUser()
        {
            return clsDataUsers.UpdateUserInformation(this.UserID, this.RoleID, this.IsActive, this.Username, this.UserPassword, this.CurrentPermissions);
        }

        private bool _AddUser()
        {
            this.UserID = clsDataUsers.InsertUser(this.PersonID, this.RoleID, this.IsActive, this.Username, this.UserPassword, this.CurrentPermissions);
            return this.UserID != -1;
        }

        public bool Save()
        {
            if (_Mode == enMode.UpdateMode)
            {
                return _UpdateUser();
            }
            else if (_Mode == enMode.AddMode)
            {
                if (_AddUser())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }

            }

            return false;
        }

        public bool Delete()
        {
            return clsDataUsers.DeleteUser(this.UserID);
        }

        static public bool IsAdmin(clsUsers user)
        {
            bool IsAdmin = false;

            if (user != null)
            {
                IsAdmin = user.Role.Permissions == -1 ? true : false;
            }

            return IsAdmin;

        }

        static public bool HasPermission(clsUsers user, long permission)
        {
            bool HasPermission = false;

            if (user != null)
            {
                HasPermission = user.CurrentPermissions != null ?
                    (permission & user.CurrentPermissions) == permission :
                    (permission & user.Role.Permissions) == permission;

            }

            return HasPermission;
        }

        static public bool isUserExist(int ID)
        {
            return clsDataUsers.IsUserExist(ID);
        }
        static public int GetUserIDByFirstName(string FirstName)
        {
            return clsDataUsers.GetUserIDByFirstName(FirstName);
        }

    }
}
