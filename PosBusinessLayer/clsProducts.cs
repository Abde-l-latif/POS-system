using PosDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PosBusinessLayer
{
    public class clsProducts
    {

        enum enMode { AddMode , UpdateMode }

        enMode _Mode = enMode.AddMode;

        public int ProductID { get; private set; } 

        public string ProductName { get; set; }

        public string BarCode { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal BuyingPrice { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }

        public decimal buyingPrice { get; set; }

        public int CategoryID { get; set; }

        public int CreatedByUserID { get; set; }

        public string ProductImage { get; set; } = "";

        public decimal ? TaxRate { get; set; }

        public clsProducts()
        {
            _Mode = enMode.AddMode;
        }

        static public DataTable GetAllProducts()
        {
            return clsDataProducts.GetAllProducts();
        }

        static public DataTable GetProductsByName(string name, short Page, short PageSize)
        {
            return clsDataProducts.GetProductsByName(name , Page , PageSize);
        }

        private bool _AddProduct()
        {

            this.ProductID = clsDataProducts.InsertProducts(this.ProductName, this.BarCode, this.SellingPrice, this.BuyingPrice, this.StockQuantity, this.IsActive,
            this.CategoryID, this.CreatedByUserID, this.ProductImage, this.TaxRate);

            return false;
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                _AddProduct();
                _Mode = enMode.UpdateMode; 
                return true;
            }

            else return false;
        }

    }
}
