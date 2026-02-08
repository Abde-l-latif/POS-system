using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    public class clsDataSettings
    {
        static public string ConnectionString = $@"server={clsSecureInfo.server};database={clsSecureInfo.database};
        user ID={clsSecureInfo.username};password={clsSecureInfo.password}";

        static public decimal GetSystemTax()
        {
            decimal Vat = 0;

            string Query = "select Vat from Settings where SettingID = 1"; 

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        connection.Open(); 
                        object Result = command.ExecuteScalar();

                        if (Result != null)
                            Vat = Convert.ToDecimal(Result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }

            return Vat;

        }
    }
}
