using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    public class clsDataPeople
    {
        
        static public bool SelectPersonByID(int PersonID , ref string FirstName, ref string LastName, ref DateTime BirthDate,
            ref string PersonAddress, ref string PersonImage, ref string Gender)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"SELECT * FROM Persons WHERE PersonID = @PersonID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;

                                FirstName = (string)Reader["FirstName"];
                                LastName = (string)Reader["LastName"];
                                BirthDate = (DateTime)Reader["BirthDate"];
                                PersonAddress = (string)Reader["PersonAddress"];

                                if(Reader["PersonImage"] == DBNull.Value)
                                    PersonImage = "";                
                                else
                                    PersonImage = (string)Reader["PersonImage"];


                                Gender = (string)Reader["Gender"];
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
        static public DataTable SelectAllPeopleData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string query = @"SELECT P.PersonID , P.FirstName, P.LastName, P.BirthDate, P.PersonAddress , P.PersonImage , 
                                    CASE P.Gender
	                                    WHEN 'M' THEN 'Male'
	                                    ELSE 'Female'
                                    END AS Gender ,
                                    Phones.PhoneNumber
                                    FROM Persons P
                                    inner join Phones on P.PersonID = Phones.PersonID";
                try
                {

                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {
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

        static public int InsertPerson(string FirstName, string LastName, DateTime BirthDate, string PersonAddress, string PersonImage, string Gender)
        {
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();
                string query = @"INSERT INTO Persons (FirstName , LastName , BirthDate , PersonAddress, PersonImage , Gender )
                VALUES (@FirstName , @LastName , @BirthDate , @PersonAddress, @PersonImage , @Gender );
                SELECT SCOPE_IDENTITY();";

                try
                {

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

                }
                catch (Exception ex)
                {
                    throw ex;
                }


                return -1;
            }
        }

        static public bool UpdatePerson(int PersonID , string FirstName, string LastName, DateTime BirthDate, string PersonAddress, string PersonImage, string Gender)
        {
            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {

                int EffectedRows = 0; 
                Connection.Open();

                string query = @"UPDATE Persons SET FirstName = @FirstName , LastName = @LastName, BirthDate = @BirthDate , PersonAddress = @PersonAddress ,
                PersonImage = @PersonImage , Gender = @Gender  WHERE PersonID = @PersonID;";

                try
                {

                    using (SqlCommand cmd = new SqlCommand(query, Connection))
                    {

                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@BirthDate", BirthDate);
                        cmd.Parameters.AddWithValue("@PersonAddress", PersonAddress);

                        if (PersonImage == "")
                            cmd.Parameters.AddWithValue("@PersonImage", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@PersonImage", PersonImage);

                        cmd.Parameters.AddWithValue("@Gender", Gender);

                        int result = cmd.ExecuteNonQuery();

                        EffectedRows =  Convert.ToInt32(result);
                        
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }


                return EffectedRows != 0 ;
            }
        }
    }
}
