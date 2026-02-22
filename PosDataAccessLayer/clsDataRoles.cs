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
                string Query = "SELECT * FROM Roles;";

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

        static public bool FindByRoleID(int RoleID, ref string RoleName, ref long Permissions)
        {

            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"select top 1 * from Roles where RoleID = @RoleID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@RoleID", RoleID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                Permissions = (long)Reader["Permissions"];
                                RoleID = (int)Reader["RoleID"];
                                RoleName = (string)Reader["RoleName"];
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

        static public int InsertRoles(string RoleName, long Permissions)
        {
            int result = -1;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"INSERT INTO Roles (RoleName , Permissions)
                VALUES (@RoleName , @Permissions);
                SELECT SCOPE_IDENTITY();";

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@RoleName", RoleName);
                        command.Parameters.AddWithValue("@Permissions", Permissions);

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

        static public bool UpdateRoles(int RoleID, string RoleName, long Permissions)
        {
            int EffectedRows = -1;

            try
            {
                string Query = @"Update Roles 
                            	set Permissions = @Permissions , 
                            	RoleName = @RoleName 
                            		WHERE RoleID = @RoleID;";

                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@RoleID", RoleID);
                        cmd.Parameters.AddWithValue("@RoleName", RoleName);
                        cmd.Parameters.AddWithValue("@Permissions", Permissions);


                        Connection.Open();

                        EffectedRows = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EffectedRows > 0;

        }

        public static bool DeleteRoles(int id)
        {
            string query = "DELETE FROM Roles WHERE RoleID = @RoleID";

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RoleID", id);
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
