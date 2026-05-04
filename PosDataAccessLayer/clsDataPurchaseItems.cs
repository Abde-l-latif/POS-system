
using System;
using System.Data;
using System.Data.SqlClient;
using PosDataAccessLayer;


public static class clsDataPurchaseItems
{
    public static int InsertPurchaseItems(int Quantity, decimal UnitBuyingPrice, int ProductID, int PurchaseID, DateTime CreatedAt, DateTime UpdatedAt)
    {
        int ID = -1;
        
        string query = $@"INSERT INTO PurchaseItems (Quantity, UnitBuyingPrice, ProductID, PurchaseID, CreatedAt, UpdatedAt) VALUES
        (@Quantity, @UnitBuyingPrice, @ProductID, @PurchaseID, @CreatedAt, @UpdatedAt) ;
        SELECT SCOPE_IDENTITY();";
        
        try
        {
            using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                 using(SqlCommand cmd = new SqlCommand(query, conn))
                 {

                    cmd.Parameters.AddWithValue("@Quantity", Quantity) ;
                    cmd.Parameters.AddWithValue("@UnitBuyingPrice", UnitBuyingPrice) ;
                    cmd.Parameters.AddWithValue("@ProductID", ProductID) ;
                    cmd.Parameters.AddWithValue("@PurchaseID", PurchaseID) ;
                    cmd.Parameters.AddWithValue("@CreatedAt", CreatedAt) ;
                    cmd.Parameters.AddWithValue("@UpdatedAt", UpdatedAt) ;
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

    public static DataTable GetAllPurchaseItems()
    {
        DataTable dt = new DataTable();

        string query = "SELECT * FROM PurchaseItems";

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

    public static DataTable GetAllPurchaseItemsByPurchaseID(int ID)
    {
        DataTable dt = new DataTable();

        string query = "select p.ProductID, Products.ProductName, p.Quantity, p.UnitBuyingPrice  from PurchaseItems p inner join Products on Products.ProductID = p.ProductID where p.PurchaseID = @id;";

        try
        {

            using (SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    conn.Open(); 
                    dt.Load(cmd.ExecuteReader());
                }
            }

        }
        catch (Exception Ex)
        {
            throw;
        }


        return dt;
    }

    public static bool DeletePurchaseItems(int id)
    {
        string query = "DELETE FROM PurchaseItems WHERE PurchaseItemID = @PurchaseItemID";
        
        try
        {
            using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PurchaseItemID", id);
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

    static public bool UpdatePurchaseItems(int ID, int Quantity, decimal UnitBuyingPrice, DateTime UpdatedAt)
    {
        int EffectedRows = -1;

        try
        {
            string query = @"Update PurchaseItems 
                        	set 
                                Quantity = @Quantity, UnitBuyingPrice = @UnitBuyingPrice, UpdatedAt = @UpdatedAt
                        		WHERE PurchaseItemID = @PurchaseItemID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    
                    cmd.Parameters.AddWithValue("@PurchaseItemID", ID);   
                    cmd.Parameters.AddWithValue("@Quantity", Quantity) ;
                    cmd.Parameters.AddWithValue("@UnitBuyingPrice", UnitBuyingPrice) ;
                    cmd.Parameters.AddWithValue("@UpdatedAt", UpdatedAt) ;
                    
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

    static public bool GetPurchaseItemsByProductIDandPurchaseID(ref int ID, ref int Quantity, ref decimal UnitBuyingPrice, int ProductID, int PurchaseID, ref DateTime CreatedAt, ref DateTime UpdatedAt)
    {
        bool IsFound = false;

        using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
        {
            Connection.Open();

            string Query = @"SELECT * FROM PurchaseItems WHERE ProductID = @ProductID and PurchaseID = @PurchaseID;";

            try
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@PurchaseID", PurchaseID);
                    Command.Parameters.AddWithValue("@ProductID", ProductID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;

                            Quantity = (int)Reader["Quantity"];
                            UnitBuyingPrice = (decimal)Reader["UnitBuyingPrice"];
                            ID = (int)Reader["PurchaseItemID"];
                            CreatedAt = (DateTime)Reader["CreatedAt"];
                            UpdatedAt = (DateTime)Reader["UpdatedAt"];
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

    static public bool GetPurchaseItemsById(int ID, ref int Quantity, ref decimal UnitBuyingPrice, ref int ProductID, ref int PurchaseID, ref DateTime CreatedAt, ref DateTime UpdatedAt)
    {
        bool IsFound = false;

        using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
        {
            Connection.Open();

            string Query = @"SELECT * FROM PurchaseItems WHERE PurchaseItemID = @PurchaseItemID;";

            try
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@PurchaseItemID", ID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;

                            Quantity = (int)Reader["Quantity"];
                            UnitBuyingPrice = (decimal)Reader["UnitBuyingPrice"];
                            ProductID = (int)Reader["ProductID"];
                            PurchaseID = (int)Reader["PurchaseID"];
                            CreatedAt = (DateTime)Reader["CreatedAt"];
                            UpdatedAt = (DateTime)Reader["UpdatedAt"];
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




