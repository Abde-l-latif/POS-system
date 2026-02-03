using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosDataAccessLayer
{
    public class clsDataProducts
    {
        static public DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    string Query = @"SELECT P.ProductID , P.ProductName, P.BarCode, P.SellingPrice, P.IsActive, C.CategoryName,
                    P.CreatedByUserID, P.ProductImage FROM Products P INNER JOIN Categories C ON P.CategoryID = C.CategoryID;";

                    using (SqlCommand cmd = new SqlCommand(Query, Connection))
                    {
                        Connection.Open();

                        using(SqlDataReader Reader = cmd.ExecuteReader())
                        {
                            dt.Load(Reader);    
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

        static public int InsertProducts(string ProductName , string BarCode , decimal SellingPrice , decimal BuyingPrice , int StockQuantity , bool IsActive,
            int CategoryID , int CreatedByUserID , string ProductImage, decimal? TaxRate)
        {
            int newID = -1; 

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddProduct", Connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ProductName", ProductName);
                        cmd.Parameters.AddWithValue("@BarCode", BarCode);
                        cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
                        cmd.Parameters.AddWithValue("@BuyingPrice", BuyingPrice);
                        cmd.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        if(ProductImage != "")
                            cmd.Parameters.AddWithValue("@ProductImage", ProductImage);

                        if(TaxRate.HasValue)
                            cmd.Parameters.AddWithValue("@TaxRate", TaxRate);

                        var outParam = new SqlParameter("@ProductID", SqlDbType.Int);
                        outParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outParam);

                        Connection.Open();

                        cmd.ExecuteNonQuery();

                        newID = (int)cmd.Parameters["@ProductID"].Value;

                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return newID;

        }
    }
}
