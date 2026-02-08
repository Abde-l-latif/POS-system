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

        static public DataTable GetAllProducts(short Page, short PageSize, string Column, string OrderBy)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    string Query = $@"SELECT P.ProductID , P.ProductName, P.BarCode, P.SellingPrice, P.IsActive, C.CategoryName,
                    P.CreatedByUserID, P.ProductImage FROM Products P INNER JOIN Categories C ON P.CategoryID = C.CategoryID
                    ORDER BY [{Column}] {OrderBy}
                    OFFSET @Offset Rows
                    FETCH NEXT (@PageSize + 1) ROWS ONLY;";

                    using (SqlCommand cmd = new SqlCommand(Query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@Offset", (Page * PageSize));
                        cmd.Parameters.AddWithValue("@PageSize", PageSize);
                        Connection.Open();

                        using (SqlDataReader Reader = cmd.ExecuteReader())
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

        static public DataTable GetProductsByName(string ProductName, short Page, short PageSize)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    string Query = @"SELECT * FROM Products WHERE ProductName LIKE @ProductName 
                        ORDER BY ProductName
                        OFFSET @Offset ROWS
                        FETCH NEXT (@PageSize + 1) ROWS ONLY;";

                    using (SqlCommand cmd = new SqlCommand(Query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", ProductName + '%');
                        cmd.Parameters.AddWithValue("@Offset", (Page * PageSize));
                        cmd.Parameters.AddWithValue("@PageSize", PageSize);

                        Connection.Open();

                        using (SqlDataReader Reader = cmd.ExecuteReader())
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

        static public int UpdateProducts(int ProductID, string ProductName, string BarCode, decimal SellingPrice, decimal BuyingPrice, int StockQuantity, bool IsActive,
        int CategoryID, int CreatedByUserID, string ProductImage, decimal? TaxRate)
        {
            int EffectedRows = -1;

            try
            {
                string Query = @"Update Products 
                            	set ProductName = @ProductName , 
                            	BarCode = @BarCode, 
                            	SellingPrice = @SellingPrice,
                            	BuyingPrice = @BuyingPrice,
                            	StockQuantity = @StockQuantity,
                            	IsActive = @IsActive,
                            	UpdatedAt = GETDATE() , 
                            	CategoryID = @CategoryID,
                            	CreatedByUserID = @CreatedByUserID,
                            	ProductImage = @ProductImage,
                            	TaxRate = @TaxRate
                            		WHERE ProductID = @ProductID;";

                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", ProductID);
                        cmd.Parameters.AddWithValue("@ProductName", ProductName);
                        cmd.Parameters.AddWithValue("@BarCode", BarCode);
                        cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
                        cmd.Parameters.AddWithValue("@BuyingPrice", BuyingPrice);
                        cmd.Parameters.AddWithValue("@StockQuantity", StockQuantity);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        if (ProductImage != "")
                            cmd.Parameters.AddWithValue("@ProductImage", ProductImage);
                        else
                            cmd.Parameters.AddWithValue("@ProductImage", DBNull.Value);


                        if (TaxRate.HasValue)
                            cmd.Parameters.AddWithValue("@TaxRate", TaxRate);
                        else
                            cmd.Parameters.AddWithValue("@TaxRate", DBNull.Value);


                        Connection.Open();

                        EffectedRows = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return EffectedRows;

        }

        static public bool GetProductId(int ProductID, ref string ProductName, ref string BarCode, ref decimal SellingPrice, ref decimal BuyingPrice, ref int StockQuantity, ref bool IsActive,
        ref DateTime CreatedAt, ref DateTime UpdatedAt, ref int CategoryID, ref int CreatedByUserID, ref string ProductImage, ref decimal TaxRate)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                Connection.Open();

                string Query = @"select * from Products WHERE ProductID = @ProductID;";

                try
                {
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ProductID", ProductID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;

                                ProductName = (string)Reader["ProductName"];
                                BarCode = (string)Reader["BarCode"];
                                SellingPrice = (decimal)Reader["SellingPrice"];
                                BuyingPrice = (decimal)Reader["BuyingPrice"];
                                StockQuantity = (int)Reader["StockQuantity"];
                                IsActive = (bool)Reader["IsActive"];
                                CreatedAt = (DateTime)Reader["CreatedAt"];
                                UpdatedAt = (DateTime)Reader["UpdatedAt"];
                                CategoryID = (int)Reader["CategoryID"];
                                CreatedByUserID = (int)Reader["CreatedByUserID"];
                                TaxRate = (decimal)Reader["TaxRate"];


                                if (Reader["ProductImage"] == DBNull.Value)
                                    ProductImage = "";
                                else
                                    ProductImage = (string)Reader["ProductImage"];
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

        static public int GetIdOfFilteredProduct(string Column , string Value)
        {
            int ProductID = -1; 

            string Query = $"SELECT ProductID FROM Products WHERE [{Column}] = @Value";
            
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(Query, Connection))
                    {
                        cmd.Parameters.AddWithValue("@Value", Value);

                        Connection.Open();

                        object result = cmd.ExecuteScalar();

                        if(result != null)
                            ProductID = Convert.ToInt32(result);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }

            return ProductID;
        }
    }
}
