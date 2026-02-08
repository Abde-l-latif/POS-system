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

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public decimal buyingPrice { get; set; }

        public int CategoryID { get; set; }

        public int CreatedByUserID { get; set; }

        public string ProductImage { get; set; } = "";

        public decimal ? TaxRate { get; set; }

        public clsProducts()
        {
            _Mode = enMode.AddMode;
        }

        public clsProducts(int ProductID, string ProductName, string BarCode, decimal SellingPrice, decimal BuyingPrice, int StockQuantity, bool IsActive,
        DateTime CreatedAt, DateTime UpdatedAt, int CategoryID, int CreatedByUserID, string ProductImage, decimal TaxRate)
        {
            _Mode = enMode.UpdateMode;
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.BarCode = BarCode;
            this.SellingPrice = SellingPrice;
            this.BuyingPrice = BuyingPrice;
            this.StockQuantity = StockQuantity;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.CategoryID = CategoryID;
            this.CreatedByUserID = CreatedByUserID;
            this.ProductImage = ProductImage;
            this.TaxRate = TaxRate;
        }


        static public DataTable GetAllProducts()
        {
            return clsDataProducts.GetAllProducts();
        }

        static public DataTable GetAllProducts(short Page, short PageSize, string Column, string OrderBy)
        {
            return clsDataProducts.GetAllProducts(Page, PageSize, Column, OrderBy); 
        }

        static public DataTable GetProductsByName(string name, short Page, short PageSize)
        {
            return clsDataProducts.GetProductsByName(name , Page , PageSize);
        }

        static public clsProducts GetProductByID(int ProductID)
        {
            string ProductName = "", BarCode = "", ProductImage = "";
            decimal SellingPrice = 0, BuyingPrice = 0, TaxRate = 0;
            int StockQuantity = 0;
            bool IsActive = false;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;
            int CategoryID = -1, CreatedByUserID = -1;

            if (clsDataProducts.GetProductId(ProductID, ref ProductName, ref BarCode, ref SellingPrice, ref BuyingPrice, ref StockQuantity, ref IsActive,
            ref CreatedAt, ref UpdatedAt, ref CategoryID, ref CreatedByUserID, ref ProductImage, ref TaxRate))
            {
                return new clsProducts(ProductID, ProductName, BarCode, SellingPrice, BuyingPrice, StockQuantity, IsActive,
                CreatedAt, UpdatedAt, CategoryID, CreatedByUserID, ProductImage, TaxRate);
            }
            else
                return null; 

        }

        static public int GetIdOfFilteredProduct(string Column, string Value)
        {
            return clsDataProducts.GetIdOfFilteredProduct(Column, Value);
        }

        private bool _AddProduct()
        {

            this.ProductID = clsDataProducts.InsertProducts(this.ProductName, this.BarCode, this.SellingPrice, this.BuyingPrice, this.StockQuantity, this.IsActive,
            this.CategoryID, this.CreatedByUserID, this.ProductImage, this.TaxRate);

            return false;
        }


        private bool _UpdateProducts()
        {
            return clsDataProducts.UpdateProducts(this.ProductID , this.ProductName, this.BarCode , this.SellingPrice, this.BuyingPrice, this.StockQuantity, this.IsActive,
            this.CategoryID, this.CreatedByUserID, this.ProductImage, this.TaxRate) != -1; 
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                _AddProduct();
                _Mode = enMode.UpdateMode;
                return true;
            }
            else
                return _UpdateProducts(); 
        }

    }
}
