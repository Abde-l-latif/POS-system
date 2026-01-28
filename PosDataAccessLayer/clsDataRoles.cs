using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    public class clsDataRoles
    {

        static public DataTable GetAllRoles()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                try
                {

                    using (SqlCommand command = new SqlCommand("sp_GetAllRoles", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

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
    }
}
