using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    public class clsDataPhones
    {
        static public int InsertPhone(string PhoneNumber, int PersonID)
        {
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();
                string query = @"INSERT INTO Phones (PhoneNumber, PersonID) VALUES (@PhoneNumber , @PersonID) ;
                SELECT SCOPE_IDENTITY();";

                try
                {

                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return -1;
            }
        }

        static public DataTable SelectAllPersonPhones(int PersonID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string query = @"SELECT * FROM Phones WHERE PersonID = @PersonID;";
                try
                {

                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@PersonID" , PersonID);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                dt.Load(rd);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return dt;
            }


        }

        static public bool DeleteByPhoneID(int PhoneID)
        {
   
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {

                bool Deleted = false; 

                Connection.Open();

                string query = @"DELETE FROM Phones Where PhoneID = @PhoneID";

                try
                {

                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@PhoneID", PhoneID);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Deleted = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Deleted;
            }
        }

        static public bool UpdatePhoneNumber(int PhoneID , string PhoneNumber)
        {

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {

                int RowsEffected = 0;

                Connection.Open();

                string query = @"UPDATE Phones SET PhoneNumber = @PhoneNumber WHERE PhoneID = @PhoneID;";

                try
                {

                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@PhoneID", PhoneID);
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                        int result = cmd.ExecuteNonQuery();
                      
                        RowsEffected = Convert.ToInt32(result);         
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return RowsEffected != 0;
            }
        }
    }
}
