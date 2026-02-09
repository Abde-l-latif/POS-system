using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    public class clsDataCategories
    {
        static public DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string Query = "SELECT * FROM Categories;";

                try
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return dt;
        }

        static public bool FindCategory(int CategoryID, ref string CategoryName, ref bool IsActive, ref DateTime CreatedAt, ref  DateTime UpdatedAt)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"Select * from Categories where CategoryID = @CategoryID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;

                                CategoryName = (string)Reader["CategoryName"];
                                IsActive = (bool)Reader["IsActive"];
                                CreatedAt = (DateTime)Reader["CreatedAt"];
                                UpdatedAt = (DateTime)Reader["UpdatedAt"];

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    IsFound = false;
                    throw ex;
                }

            }

            return IsFound;
        }

        static public bool FindCategoryByName(ref int CategoryID, string CategoryName, ref bool IsActive, ref DateTime CreatedAt, ref DateTime UpdatedAt)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"Select * from Categories where CategoryName = @CategoryName;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;

                                CategoryID = (int)Reader["CategoryID"];
                                IsActive = (bool)Reader["IsActive"];
                                CreatedAt = (DateTime)Reader["CreatedAt"];
                                UpdatedAt = (DateTime)Reader["UpdatedAt"];

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    IsFound = false;
                    throw ex;
                }

            }

            return IsFound;
        }

        static public int AddCategory(string CategoryName, bool IsActive)
        {
            int ID = -1;

            string Query = @"INSERT INTO Categories VALUES (@CategoryName, @IsActive, GETDATE(), GETDATE());
                               SELECT SCOPE_IDENTITY()";

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CategoryName", CategoryName);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);

                        Connection.Open();

                        object result = Command.ExecuteScalar();

                        if(result != null)
                            ID = Convert.ToInt32(result);

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ID; 

        }

        static public bool UpdateCategory(int CategoryID, string CategoryName, bool IsActive)
        {
            int EffectedRows = -1;

            string Query = @"UPDATE Categories SET CategoryName = @CategoryName,
                                                    IsActive = @IsActive,
                                                    UpdatedAt = GETDATE() WHERE CategoryID = @CategoryID;";

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        Command.Parameters.AddWithValue("@CategoryName", CategoryName);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);

                        Connection.Open();

                        int result = Command.ExecuteNonQuery();

                        EffectedRows = result;

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EffectedRows > 0;

        }
    }
}
