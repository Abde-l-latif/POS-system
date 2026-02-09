using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        static public clsCategories GetCategoryByName(string Name)
        {
            int ID = -1;
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;

            if (clsDataCategories.FindCategoryByName(ref ID, Name, ref IsActive, ref CreatedAt, ref UpdatedAt))
            {
                return new clsCategories(ID, Name, IsActive, CreatedAt, UpdatedAt);
            }
            else
                return null;
        }

        static public DataTable GetAllCategories()
        {
            return clsDataCategories.GetAllCategories();
        }

        private bool _AddCategory()
        {
            this.CategoryID = clsDataCategories.AddCategory(this.CategoryName, this.IsActive); 
            return this.CategoryID != -1; 
        }

        private bool _UpdateCategory()
        {
            return clsDataCategories.UpdateCategory(this.CategoryID, this.CategoryName , this.IsActive);
        }

        public bool Save()
        {
            if(_Mode == enMode.AddMode)
            {
                if (_AddCategory())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
            }
            else if(_Mode == enMode.UpdateMode)
            {
                return _UpdateCategory();
            }

            return false; 
        }

    }
}
