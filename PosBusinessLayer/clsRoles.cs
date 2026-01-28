using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsRoles
    {
        static public DataTable GetAllRoles()
        {
            return clsDataRoles.GetAllRoles();
        }
    }
}
