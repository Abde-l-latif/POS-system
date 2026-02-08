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
    public class clsCategories
    {

        enum enMode { AddMode , UpdateMode }

        enMode _Mode = enMode.AddMode;

        public int CategoryID { get; private set; }
        
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        public clsCategories() {  _Mode = enMode.AddMode; }

        public clsCategories(int CategoryID, string CategoryName, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            _Mode = enMode.UpdateMode;
        }

        static public clsCategories GetCategoryByID(int id)
        {
            string Name = "";
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;

            if(clsDataCategories.FindCategory(id, ref Name, ref IsActive, ref CreatedAt, ref UpdatedAt))
            {
                return new clsCategories(id, Name, IsActive, CreatedAt, UpdatedAt);
            }
            else
                return null;
        }

        static public DataTable GetAllCategories()
        {
            return clsDataCategories.GetAllCategories();
        }

    }
}
