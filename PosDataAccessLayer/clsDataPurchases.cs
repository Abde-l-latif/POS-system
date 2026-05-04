using System;
using System.Data;
using System.Data.SqlClient;
using PosDataAccessLayer;


public static class clsDataPurchases
{
    public static int InsertPurchases(DateTime PurchaseDate, int CreatedByUserID, int SupplierID, bool IsDeleted, DateTime CreatedAt, DateTime UpdatedAt,
        string InternalInvoiceNo, string SupplierInvoiceNo)
    {
        int ID = -1;
        
        string query = $@"INSERT INTO Purchases (PurchaseDate, CreatedByUserID, SupplierID, IsDeleted, CreatedAt, UpdatedAt, InternalInvoiceNo, SupplierInvoiceNo) VALUES
        (@PurchaseDate, @CreatedByUserID, @SupplierID, @IsDeleted, @CreatedAt, @UpdatedAt, @InternalInvoiceNo, @SupplierInvoiceNo) ;
        SELECT SCOPE_IDENTITY();";
        
        try
        {
            using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                 using(SqlCommand cmd = new SqlCommand(query, conn))
                 {

                    cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate) ;
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID) ;
                    cmd.Parameters.AddWithValue("@SupplierID", SupplierID) ;
                    cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted) ;
                    cmd.Parameters.AddWithValue("@CreatedAt", CreatedAt) ;
                    cmd.Parameters.AddWithValue("@UpdatedAt", UpdatedAt) ;

                    if(InternalInvoiceNo == "")
                        cmd.Parameters.AddWithValue("@InternalInvoiceNo", DBNull.Value) ;
                    else
                        cmd.Parameters.AddWithValue("@InternalInvoiceNo", InternalInvoiceNo) ;

                    if (SupplierInvoiceNo == "")
                        cmd.Parameters.AddWithValue("@SupplierInvoiceNo", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@SupplierInvoiceNo", SupplierInvoiceNo);


                    conn.Open();

                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                     
                 }
            }


        }
        catch(Exception ex)
        {
            throw;
        }
        
        return ID;

    }

    public static string GetGeneratedInvoiceNo()
    {
        string InvoiceNo = "";

        string query = @"Declare @NextNumber int 

                        SET @NextNumber = next value for PurchaseSeq;

                        Select 'PUR-' + FORMAT(@NextNumber , '00000');";
        try
        {
            using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if(result != null && result != DBNull.Value)
                    {
                        InvoiceNo = (string)result;
                    }
                }
            }
        }
        catch(Exception ex)
        {
            throw;
        }

        return InvoiceNo;
    }

    public static DataTable GetAllPurchases()
    {
        DataTable dt = new DataTable();

        string query = "SELECT * FROM Purchases";

        try
        {

        using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
        {
            using(SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
        }

        }
        catch(Exception Ex)
        { 
            throw;
        }


        return dt;
    }

    public static bool DeletePurchases(int id)
    {
        string query = "DELETE FROM Purchases WHERE PurchaseID = @PurchaseID";
        
        try
        {
            using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PurchaseID", id);
                    conn.Open();
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            
        }
        catch(Exception Ex)
        { 
            throw ; 
        }
    }


    static public bool UpdatePurchases(int ID, DateTime PurchaseDate, int CreatedByUserID, int SupplierID, bool IsDeleted,
        DateTime UpdatedAt, string InternalInvoiceNo, string SupplierInvoiceNo)
    {
        int EffectedRows = -1;

        try
        {
            string query = @"Update Purchases 
                        	set 
                                PurchaseDate = @PurchaseDate, CreatedByUserID = @CreatedByUserID, SupplierID = @SupplierID, IsDeleted = @IsDeleted, UpdatedAt = @UpdatedAt, InternalInvoiceNo = @InternalInvoiceNo, SupplierInvoiceNo = @SupplierInvoiceNo
                        		WHERE PurchaseID = @PurchaseID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    
                    cmd.Parameters.AddWithValue("@PurchaseID", ID);   
                    cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate) ;
                    cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID) ;
                    cmd.Parameters.AddWithValue("@SupplierID", SupplierID) ;
                    cmd.Parameters.AddWithValue("@IsDeleted", IsDeleted) ;
                    cmd.Parameters.AddWithValue("@UpdatedAt", UpdatedAt) ;

                    if (InternalInvoiceNo == "")
                        cmd.Parameters.AddWithValue("@InternalInvoiceNo", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@InternalInvoiceNo", InternalInvoiceNo);

                    if (SupplierInvoiceNo == "")
                        cmd.Parameters.AddWithValue("@SupplierInvoiceNo", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@SupplierInvoiceNo", SupplierInvoiceNo);

                    Connection.Open();

                    EffectedRows = cmd.ExecuteNonQuery();

                }
            }
        }
        catch (Exception ex)
        {
            throw ;
        }

        return EffectedRows > 0;

    }


    static public bool GetPurchasesById(int ID, ref DateTime PurchaseDate, ref int CreatedByUserID, ref int SupplierID, ref bool IsDeleted, ref DateTime CreatedAt, ref DateTime UpdatedAt, ref string InternalInvoiceNo, ref string SupplierInvoiceNo)
    {
        bool IsFound = false;

        using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
        {
            Connection.Open();

            string Query = @"SELECT * FROM Purchases WHERE PurchaseID = @PurchaseID;";

            try
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@PurchaseID", ID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;

                            PurchaseDate = (DateTime)Reader["PurchaseDate"];
                            CreatedByUserID = (int)Reader["CreatedByUserID"];
                            SupplierID = (int)Reader["SupplierID"];
                            IsDeleted = (bool)Reader["IsDeleted"];
                            CreatedAt = (DateTime)Reader["CreatedAt"];
                            UpdatedAt = (DateTime)Reader["UpdatedAt"];
                            if (Reader["InternalInvoiceNo"] == DBNull.Value)
                                InternalInvoiceNo = "";
                            else
                                InternalInvoiceNo = (string)Reader["InternalInvoiceNo"];

                            if (Reader["SupplierInvoiceNo"] == DBNull.Value)
                                SupplierInvoiceNo = "";
                            else
                                SupplierInvoiceNo = (string)Reader["SupplierInvoiceNo"];


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        return IsFound;
    }    

}




