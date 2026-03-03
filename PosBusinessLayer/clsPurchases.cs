using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosBusinessLayer
{
    public class clsPurchases
    {
        enum enMode { AddMode, UpdateMode };

        private enMode _Mode = enMode.AddMode;

        public int PurchaseID { get; private set; }

        public DateTime PurchaseDate { get; set; }

        public int CreatedByUserID { get; set; }

        public clsUsers User { get; }

        public int SupplierID { get; set; }

        public clsSupplier Supplier { get; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string InternalInvoiceNo { get; set; }

        public string SupplierInvoiceNo { get; set; }

        public clsPurchases()
        {
            _Mode = enMode.AddMode;
        }

        private bool _AddPurchases()
        {
            this.PurchaseID = clsDataPurchases.InsertPurchases(PurchaseDate, CreatedByUserID, SupplierID, IsDeleted, DateTime.Now, DateTime.Now, 
                                clsDataPurchases.GetGeneratedInvoiceNo() , SupplierInvoiceNo);
            return this.PurchaseID != -1;
        }

        public bool Save()
        {
            if (_Mode == enMode.AddMode)
            {
                 if(_AddPurchases())
                 {
                     _Mode = enMode.UpdateMode;
                     return true;
                 }
            }

            return false;

        }
    }
}
