using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    public class clsDataPeople
    {
        static public int InsertPerson(string FirstName, string LastName, DateTime BirthDate, string PersonAddress, string PersonImage, char Gender)
        {
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();
                string query = @"INSERT INTO Persons (FirstName , LastName , BirthDate , PersonAddress, PersonImage , Gender )
                VALUES (@FirstName , @LastName , @BirthDate , @PersonAddress, @PersonImage , @Gender );
                SELECT SCOPE_IDENTITY();";

                using(SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@BirthDate", BirthDate);
                    cmd.Parameters.AddWithValue("@PersonAddress", PersonAddress);

                    if(PersonImage == "")
                        cmd.Parameters.AddWithValue("@PersonImage", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@PersonImage", PersonImage);

                    cmd.Parameters.AddWithValue("@Gender", Gender);

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
