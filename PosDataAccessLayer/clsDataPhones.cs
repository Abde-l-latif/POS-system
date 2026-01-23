using System;
using System.Collections.Generic;
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

                return -1;
            }
        }
    }
}
