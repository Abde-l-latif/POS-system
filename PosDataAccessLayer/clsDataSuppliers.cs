using PosDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;


public static class clsDataSuppliers
{
    public static int InsertSuppliers(int PersonID, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt)
    {
        int ID = -1;
        
        string query = $@"INSERT INTO Suppliers (PersonID, IsActive, CreatedAt, UpdatedAt) VALUES
        (@PersonID, @IsActive, @CreatedAt, @UpdatedAt) ;
        SELECT SCOPE_IDENTITY();";
        
        try
        {
            using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                 using(SqlCommand cmd = new SqlCommand(query, conn))
                 {

                    cmd.Parameters.AddWithValue("@PersonID", PersonID) ;
                    cmd.Parameters.AddWithValue("@IsActive", IsActive) ;
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

    public static DataTable GetAllSuppliers()
    {
        DataTable dt = new DataTable();

        string query = @"select S.SupplierID, P.PersonID, P.FirstName, P.LastName, S.IsActive, S.CreatedAt, S.UpdatedAt from Suppliers S
                            INNER JOIN Persons P ON P.PersonID = S.PersonID";

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

    public static bool DeleteSuppliers(int id)
    {
        string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
        
        try
        {
            using(SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierID", id);
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


    static public bool UpdateSuppliers(int ID, int PersonID, bool IsActive, DateTime UpdatedAt)
    {
        int EffectedRows = -1;

        try
        {
            string query = @"Update Suppliers 
                        	set 
                                PersonID = @PersonID, IsActive = @IsActive, UpdatedAt = @UpdatedAt
                        		WHERE SupplierID = @SupplierID;";

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    
                    cmd.Parameters.AddWithValue("@SupplierID", ID);   
                    cmd.Parameters.AddWithValue("@PersonID", PersonID) ;
                    cmd.Parameters.AddWithValue("@IsActive", IsActive) ;
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

    static public bool GetSuppliersById(int ID, ref int PersonID, ref bool IsActive, ref DateTime CreatedAt, ref DateTime UpdatedAt)
    {
        bool IsFound = false;

        using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
        {
            Connection.Open();

            string Query = @"SELECT * FROM Suppliers WHERE SupplierID = @SupplierID;";

            try
            {
                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@SupplierID", ID);

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;

                            PersonID = (int)Reader["PersonID"];
                            IsActive = (bool)Reader["IsActive"];
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




