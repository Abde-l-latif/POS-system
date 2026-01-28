using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PosDataAccessLayer
{
    public class clsDataUsers
    {

        static public bool FindByUserID(int UserID, ref int PersonID, ref int RoleID, ref bool IsActive, ref DateTime CreatedAt,
            ref DateTime UpdatedAt, ref string Username, ref string UserPassword)
        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"select top 1 * from Users where UserID = @UserID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                PersonID = (int)Reader["PersonID"];
                                RoleID = (int)Reader["RoleID"];
                                IsActive = (bool)Reader["IsActive"];
                                CreatedAt = (DateTime)Reader["CreatedAt"];
                                UpdatedAt = (DateTime)Reader["UpdatedAt"];
                                Username = (string)Reader["Username"];
                                UserPassword = (string)Reader["UserPassword"];
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

        static public bool FindByPasswordAndUsername(ref int UserID, ref int PersonID, ref int RoleID, ref bool IsActive, ref  DateTime CreatedAt,
            ref DateTime UpdatedAt, string Username, string UserPassword)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"select top 1 * from Users where Username = @Username and UserPassword = @UserPassword;" ;

                try
                {
                   using(SqlCommand Command = new SqlCommand(Query, Connection))
                   {
                       Command.Parameters.AddWithValue("@Username", Username);
                       Command.Parameters.AddWithValue("@UserPassword", UserPassword);

                       using(SqlDataReader Reader = Command.ExecuteReader())
                       {
                           if(Reader.Read())
                           {
                               IsFound = true;
                               UserID = (int)Reader["UserID"];
                               PersonID = (int)Reader["PersonID"];
                               RoleID = (int)Reader["RoleID"];
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

        static public bool UpdateUserInformation(int UserID, int RoleID, bool IsActive, string Username, string UserPassword)
        {
            bool EffectedRows = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"UPDATE Users SET RoleID = @RoleID ,
                                IsActive = @IsActive , UpdatedAt = GETDATE() ,
                                Username = @Username , UserPassword = @UserPassword Where UserID = @UserID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@UserID", UserID);
                        Command.Parameters.AddWithValue("@RoleID", RoleID);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);
                        Command.Parameters.AddWithValue("@Username", Username);
                        Command.Parameters.AddWithValue("@UserPassword", UserPassword);

                        int? result = Command.ExecuteNonQuery();

                        if(result == null || result < 1)
                             EffectedRows = false;
                        else
                            EffectedRows = true;
                    }
                }
                catch(Exception ex)
                {
                    EffectedRows = false;
                    throw ex;
                }
            }

            return EffectedRows; 
        }

        static public int InsertUser(int PersonID, int RoleID, bool IsActive, string Username, string UserPassword)
        {
            int result = -1; 

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                try
                {

                    using (SqlCommand command = new SqlCommand("sp_AddUserRow", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@RoleID", RoleID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@UserPassword", UserPassword);

                        // Output parameter
                        SqlParameter outputParam = new SqlParameter("@UserID", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                       result = (int)outputParam.Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
    }
}
