using System;
using System.Data;
using System.Data.SqlClient;



namespace PosDataAccessLayer
{
    public static class clsDataCustomers
    {
        public static int InsertCustomers(int PersonID, bool IsActive, DateTime CreatedAt, DateTime UpdatedAt)
        {
            int ID = -1;

            string query = $@"INSERT INTO Customers (PersonID, IsActive, CreatedAt, UpdatedAt) VALUES
                            (@PersonID, @IsActive, @CreatedAt, @UpdatedAt) ;
                            SELECT SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@CreatedAt", CreatedAt);
                        cmd.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);
                        conn.Open();

                        ID = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return ID;

        }

        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();

            string query = @"select C.CustomerID, P.PersonID, P.FirstName, P.LastName, C.IsActive, C.CreatedAt, C.UpdatedAt from Customers C 
                            INNER JOIN Persons P ON P.PersonID = C.PersonID";

            try
            {

                using (SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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

        public static bool DeleteCustomers(int id)
        {
            string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", id);
                        conn.Open();

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }

            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        static public bool UpdateCustomers(int ID, int PersonID, bool IsActive, DateTime UpdatedAt)
        {
            int EffectedRows = -1;

            try
            {
                string query = @"Update Customers 
                        	set 
                                PersonID = @PersonID, IsActive = @IsActive, UpdatedAt = @UpdatedAt
                        		WHERE CustomerID = @CustomerID;";

                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {

                        cmd.Parameters.AddWithValue("@CustomerID", ID);
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UpdatedAt", UpdatedAt);

                        Connection.Open();

                        EffectedRows = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return EffectedRows > 0;

        }

        static public bool GetCustomersId(int ID, ref int PersonID, ref bool IsActive, ref DateTime CreatedAt, ref DateTime UpdatedAt)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"SELECT * FROM Customers WHERE CustomerID = @CustomerID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CustomerID", ID);

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

        static public bool IsCustomerExist(int ID)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"SELECT found = 1 FROM Customers WHERE CustomerID = @CustomerID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CustomerID", ID);

                        object result = Command.ExecuteScalar();

                        if (result != null)
                            IsFound = Convert.ToInt32(result) == 1;

                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            return IsFound;
        }

        static public bool IsPersonAlreadyCustomer(int ID)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"SELECT found = 1 FROM Customers WHERE PersonID = @PersonID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", ID);

                        object result = Command.ExecuteScalar();

                        if (result != null)
                            IsFound = Convert.ToInt32(result) == 1;

                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            return IsFound;
        }

        static public int GetCustomerIDByFirstName(string FirstName)
        {
            int ID = -1;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"SELECT CustomerID FROM Customers C
                                INNER JOIN Persons P ON P.PersonID = C.PersonID
                                WHERE FirstName = @FirstName
                                ;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@FirstName", FirstName);

                        object result = Command.ExecuteScalar();

                        if (result != null)
                            ID = Convert.ToInt32(result);

                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            return ID;
        }
    }
}




