using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsPurchaseItems
    {

        enum enMode { AddMode, UpdateMode };

        private enMode _Mode = enMode.AddMode;

        public int PurchaseItemID { get; private set; }

        public int Quantity { get; set; }

        public decimal UnitBuyingPrice { get; set; }

        public int ProductID { get; set; }

        public int PurchaseID { get; set; }

        public clsProducts Product { get; }

        public clsPurchases purchase { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public clsPurchaseItems()
        {
            _Mode = enMode.AddMode;
        }

        public clsPurchaseItems(int ID, int Quantity, decimal UnitBuyingPrice, int ProductID, int PurchaseID, DateTime CreatedAt, DateTime UpdatedAt)
        {
            _Mode = enMode.UpdateMode;
            this.PurchaseItemID = ID;
            this.Quantity = Quantity;
            this.UnitBuyingPrice = UnitBuyingPrice;
            this.ProductID = ProductID;
            this.PurchaseID = PurchaseID;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            Product = clsProducts.GetProductByID(ProductID);
            purchase = clsPurchases.getPurchaseById(PurchaseID);

        }

        static public clsPurchaseItems GetPurchaseItemsById(int ID)
        {
            int Quantity = 0, ProductID = 0, PurchaseID = 0;
            decimal UnitBuyingPrice = 0;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;

            if(clsDataPurchaseItems.GetPurchaseItemsById(ID, ref Quantity, ref UnitBuyingPrice, ref ProductID, ref PurchaseID, ref CreatedAt, ref UpdatedAt))
            {
                return new clsPurchaseItems(ID, Quantity, UnitBuyingPrice, ProductID, PurchaseID, CreatedAt, UpdatedAt);
            }

            return null;
        }

        static public clsPurchaseItems GetPurchaseItemsByProductIDandPurchaseID(int PurchaseID, int ProductID)
        {
            int ItemID = -1;
            int Quantity = 0;
            decimal UnitBuyingPrice = 0;
            DateTime CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;

            if (clsDataPurchaseItems.GetPurchaseItemsByProductIDandPurchaseID(ref ItemID, ref Quantity, ref UnitBuyingPrice, ProductID, PurchaseID, ref CreatedAt, ref UpdatedAt))
            {
                return new clsPurchaseItems(ItemID, Quantity, UnitBuyingPrice, ProductID, PurchaseID, CreatedAt, UpdatedAt);
            }

            return null;
        }

        public static DataTable PurchaseItemsByPurchaseID(int ID)
        {
            return clsDataPurchaseItems.GetAllPurchaseItemsByPurchaseID(ID);
        }

        private bool _AddPurchaseItem()
        {
            this.PurchaseItemID = clsDataPurchaseItems.InsertPurchaseItems(this.Quantity, this.UnitBuyingPrice, this.ProductID, this.PurchaseID, DateTime.Now, DateTime.Now);
            return this.PurchaseItemID != -1;
        }

        private bool _UpdatePurchaseItem()
        {
            return clsDataPurchaseItems.UpdatePurchaseItems(this.PurchaseItemID, this.Quantity, this.UnitBuyingPrice, DateTime.Now);
        }   

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                if (_AddPurchaseItem())
                {
                    _Mode = enMode.UpdateMode;
                    return true;
                }
            }
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdatePurchaseItem();
            }

            return false;

        }
    }
}
