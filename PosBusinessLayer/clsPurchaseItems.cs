using System;
using System.Collections.Generic;
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

        private bool _AddPurchaseItem()
        {
            this.PurchaseItemID = clsDataPurchaseItems.InsertPurchaseItems(this.Quantity, this.UnitBuyingPrice, this.ProductID, this.PurchaseID, DateTime.Now, DateTime.Now);
            return this.PurchaseItemID != -1;
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

            return false;

        }
    }
}
