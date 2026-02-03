using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsCategories
    {

        static public DataTable GetAllCategories()
        {
            return clsDataCategories.GetAllCategories();
        }


    }
}
