using System.Data.SqlClient;
using storeModel;

namespace storeDL
{
    public class ProductSQLRepo : IProductRepo
    {
        private readonly string _connectionString;
        public ProductSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }

        public List<Products> GetAllProduct()
        {
            List<Products> ListOfproducts = new List<Products>();
            string sqlQuery = @"select * from Products";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListOfproducts.Add(new Products()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetInt32(2),
                        Description = reader.GetString(3),
                        Category = reader.GetString(4)
                    });
                }
            }

            return ListOfproducts;
        }
        public List<Products> SearchProduct(int p_ProductID)
        {
            List<Products> listProducts = new List<Products>();
            string sqlQuery = @"select * from Products where ProductID = @ProductID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@ProductID", p_ProductID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listProducts.Add(new Products()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetInt32(2),
                        Description = reader.GetString(3),
                        Category = reader.GetString(4)
                    });
                }
            }

            return listProducts;
        }
        public Products AddProduct(Products p_product)
        {
            string sqlQuery = @"insert into Products 
                            values(@ProductName, @Price, @Descriptione, @Category)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@ProductName", p_product.ProductName);
                command.Parameters.AddWithValue("@Price", p_product.Price);
                command.Parameters.AddWithValue("@Descriptione", p_product.Description);
                command.Parameters.AddWithValue("@Category", p_product.Category);
                command.ExecuteNonQuery();
            }
            return p_product;
        }
       
    }
}
