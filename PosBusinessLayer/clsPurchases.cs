using System;
using System.Collections.Generic;
using System.Data;
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

        public clsPurchases(int PurchaseID, DateTime PurchaseDate, int CreatedByUserID, int SupplierID, bool IsDeleted, DateTime CreatedAt, DateTime UpdatedAt,
        string InternalInvoiceNo, string SupplierInvoiceNo)
        {
            _Mode = enMode.UpdateMode;
            this.PurchaseID = PurchaseID;
            this.PurchaseDate = PurchaseDate;
            this.CreatedByUserID = CreatedByUserID;
            User = clsUsers.GetUserById(CreatedByUserID);
            this.SupplierID = SupplierID;
            Supplier = clsSupplier.FindSupplierByID(SupplierID);
            this.IsDeleted = IsDeleted;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.InternalInvoiceNo = InternalInvoiceNo;
            this.SupplierInvoiceNo = SupplierInvoiceNo;

        }



        private bool _AddPurchases()
        {
            this.PurchaseID = clsDataPurchases.InsertPurchases(PurchaseDate, CreatedByUserID, SupplierID, IsDeleted, DateTime.Now, DateTime.Now, 
                                clsDataPurchases.GetGeneratedInvoiceNo() , SupplierInvoiceNo);
            return this.PurchaseID != -1;
        }


        static public clsPurchases getPurchaseById(int PurchaseID)
        {
            DateTime PurchaseDate = DateTime.Now, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now;
            int CreatedByUserID = -1, SupplierID = -1;
            string InternalInvoiceNo = "", SupplierInvoiceNo = "";
            bool IsDeleted = false;

            if(clsDataPurchases.GetPurchasesById(PurchaseID, ref PurchaseDate, ref CreatedByUserID, ref SupplierID, ref IsDeleted, ref CreatedAt, ref UpdatedAt, ref InternalInvoiceNo, ref SupplierInvoiceNo))
            {
                return new clsPurchases(PurchaseID, PurchaseDate, CreatedByUserID, SupplierID, IsDeleted, CreatedAt, UpdatedAt,
                                            InternalInvoiceNo, SupplierInvoiceNo);
            }

            return null; 

        }

        private bool _UpdatePurchases()
        {
            return clsDataPurchases.UpdatePurchases( PurchaseID, PurchaseDate, CreatedByUserID, SupplierID, IsDeleted,
          UpdatedAt,  InternalInvoiceNo,  SupplierInvoiceNo);
        }

        static public DataTable GetAllPurchases()
        {
             return clsDataPurchases.GetAllPurchases();
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
            else if (_Mode == enMode.UpdateMode)
            {
                return _UpdatePurchases();
            }

            return false;

        }
    }
}
