using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsRoles
    {
        enum enMode { AddMode, UpdateMode }

        enMode _Mode = enMode.AddMode;

        public int RoleID { get; private set; }

        public string RoleName { get; set; }

        public long Permissions { get; set; }

        public clsRoles()
        {
            _Mode = enMode.AddMode;
        }

        public clsRoles(int RoleID, string RoleName, long Permissions)
        {
            _Mode = enMode.UpdateMode;
            this.RoleID = RoleID;
            this.RoleName = RoleName;
            this.Permissions = Permissions;
        }

        static public DataTable GetAllRoles()
        {
            return clsDataRoles.GetAllRoles();
        }

        private bool _AddRole()
        {
            this.RoleID = clsDataRoles.InsertRoles(this.RoleName, this.Permissions);
            return this.RoleID != -1;
        }

        private bool _UpdateRole()
        {
            return clsDataRoles.UpdateRoles(this.RoleID, this.RoleName, this.Permissions);
        }

        static public clsRoles GetRoleByID(int RoleID)
        {
            string RoleName = string.Empty;
            long Permissions = -1;
            if (clsDataRoles.FindByRoleID(RoleID, ref RoleName, ref Permissions))
                return new clsRoles(RoleID, RoleName, Permissions);
            else
                return null;
        }

        public bool Delete()
        {
            return clsDataRoles.DeleteRoles(this.RoleID);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if(_AddRole())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
            }
            else
                return _UpdateRole();

            return false;
        }
    }
}
