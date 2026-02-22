using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PosDataAccessLayer
{
    public class clsDataUsers
    {

        static public DataTable GetAllUsersInformation()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string Query = "SELECT * FROM V_UsersInformation;";

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
        static public bool FindByUserID(int UserID, ref int PersonID, ref int RoleID, ref bool IsActive, ref DateTime CreatedAt,
            ref DateTime UpdatedAt, ref string Username, ref string UserPassword, ref long? CurrentPermissions)
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
                                if(Reader["CurrentPermissions"] == DBNull.Value)
                                    CurrentPermissions = null;
                                else
                                    CurrentPermissions = (long)Reader["CurrentPermissions"];
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
            ref DateTime UpdatedAt, string Username, string UserPassword, ref long? CurrentPermissions)
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
                                if (Reader["CurrentPermissions"] == DBNull.Value)
                                    CurrentPermissions = null;
                                else
                                    CurrentPermissions = (long)Reader["CurrentPermissions"];
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

        static public bool UpdateUserInformation(int UserID, int RoleID, bool IsActive, string Username, string UserPassword, long? CurrentPermissions)
        {
            bool EffectedRows = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"UPDATE Users SET RoleID = @RoleID ,
                                IsActive = @IsActive , UpdatedAt = GETDATE() ,
                                Username = @Username , UserPassword = @UserPassword, CurrentPermissions = @CurrentPermissions Where UserID = @UserID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@UserID", UserID);
                        Command.Parameters.AddWithValue("@RoleID", RoleID);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);
                        Command.Parameters.AddWithValue("@Username", Username);
                        Command.Parameters.AddWithValue("@UserPassword", UserPassword);

                        if(CurrentPermissions == null)
                            Command.Parameters.AddWithValue("@CurrentPermissions", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@CurrentPermissions", CurrentPermissions);

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

        static public int InsertUser(int PersonID, int RoleID, bool IsActive, string Username, string UserPassword, long? CurrentPermissions)
        {
            int result = -1; 

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"INSERT INTO Users (PersonID , RoleID , IsActive , CreatedAt,  UpdatedAt , Username , UserPassword, CurrentPermissions)
                VALUES (@PersonID , @RoleID , @IsActive , GETDATE(), GETDATE() , @Username , @UserPassword, @CurrentPermissions);
                SELECT SCOPE_IDENTITY();";

                try
                {

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        command.Parameters.AddWithValue("@RoleID", RoleID);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@UserPassword", UserPassword);

                        if (CurrentPermissions == null)
                            command.Parameters.AddWithValue("@CurrentPermissions", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@CurrentPermissions", CurrentPermissions);

                        connection.Open();

                        object id = command.ExecuteScalar();

                        result = Convert.ToInt32(id);

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        static public bool IsPersonAlreadyUser(int PersonID)
        {
            bool Found = false;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string Query = "SELECT Find = 1 FROM Users WHERE PersonID = @PersonID;";
                try
                {

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if(result != null)
                            Found = Convert.ToInt32(result) == 1;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return Found;   
        }

        static public bool IsUserExist(int ID)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"SELECT found = 1 FROM Users WHERE UserID = @UserID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@UserID", ID);

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

        static public int GetUserIDByFirstName(string FirstName)
        {
            int ID = -1;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"SELECT UserID FROM Users U
            INNER JOIN Persons P ON P.PersonID = U.PersonID
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

        public static bool DeleteUser(int id)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", id);
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

    }
}
