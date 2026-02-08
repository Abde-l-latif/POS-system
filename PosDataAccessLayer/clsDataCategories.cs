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
    }
}
