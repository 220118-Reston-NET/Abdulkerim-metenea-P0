using System.Data.SqlClient;
using storeModel;

namespace storeDL
{
    public class StoreFrontSQLRepo : IStoreFrontRepo
    {
        private readonly string _connectionString;
        public StoreFrontSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
      
        
        
        ///==============================================================================================
        ///                            StoreFront
        ////////////////////////////////////////////////////////////////////////////////////////////////
        public List<StoreFront> ViewStoreFront(int p_StoreID)
        {
            List<StoreFront> listOfStoreFront = new List<StoreFront>();
            string sqlQuery = "select * from StoreFront Where StoreID = @StoreID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_StoreID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listOfStoreFront.Add(new StoreFront()
                    {
                        StoreID = reader.GetInt32(0),
                        StoreName = reader.GetString(1),
                        StoreAddress = reader.GetString(2),
                        Products = new List<Products>(reader.GetInt32(0)),
                        Orders = new List<Orders>(reader.GetInt32(0))
                    });
                }
            }

            return listOfStoreFront;
        }
        public List<StoreFront> ViewStoreFrontByName(String p_storeName)
        {
            List<StoreFront> listOfStore = new List<StoreFront>();
            string sqlQuery = "select * from StoreFront Where StoreName = @StoreName";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreName", p_storeName);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listOfStore.Add(new StoreFront()
                    {
                        StoreID = reader.GetInt32(0),
                        StoreName = reader.GetString(1),
                        StoreAddress = reader.GetString(2),
                        Products = new List<Products>(reader.GetInt32(0)),
                        Orders = new List<Orders>(reader.GetInt32(0))
                    });
                }
            }

            return listOfStore;
        }
        public StoreFront AddStoreFront(StoreFront p_store)
        {
            string sqlQuery = @"insert into StoreFront values(@StoreID,@StoreName, @StoreAddress)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_store.StoreID);
                command.Parameters.AddWithValue("@StoreName", p_store.StoreName);
                command.Parameters.AddWithValue("@StoreAddress", p_store.StoreAddress);
                command.ExecuteNonQuery();
            }
            return p_store;
        }
        public List<StoreFront> GetAllStoreFront()
        {
            List<StoreFront> ListOfStores = new List<StoreFront>();
            string sqlQuery = @"select * from StoreFront ";
                            
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListOfStores.Add(new StoreFront()
                    {
                        StoreID = reader.GetInt32(0),
                        StoreName = reader.GetString(1),
                        StoreAddress = reader.GetString(2),
                        Products = new List<Products>(reader.GetInt32(0)),
                        Orders = new List<Orders>(reader.GetInt32(0))
                    });
                }
            }

            return ListOfStores;

        }
        //=====================================================================================
        ///                      Inventory
        /// /////////////////////////////////////////////////////////////////////////////////\\
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> Inve = new List<Inventory>();
            string sqlQuery = @"select * from Inventory";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   Inve.Add(new Inventory()
                    {
                        StoreID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        Quantity = reader.GetInt32(2)
                    });
                }
            }

            return Inve;
        }
        public List<Inventory> AddProductQuantity(int p_storeId, int p_productId, int p_quantity)
        {       List<Inventory> _addQuantity = new List<Inventory>();
                string sqlQuery = @"Update Inventory 
                            set Quantity = Quantity + @Quantity where StoreID =@StoreID and ProductID = @ProductID ";
               using(SqlConnection con = new SqlConnection(_connectionString))
               {
                   con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    command.Parameters.AddWithValue("@StoreID", p_storeId);
                    command.Parameters.AddWithValue("@ProductID", p_productId);
                    command.Parameters.AddWithValue("@Quantity", p_quantity);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        _addQuantity.Add(new Inventory()
                        {
                                StoreID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(1),
                                Quantity = reader.GetInt32(2)
                        });
                    }      
               }
                return _addQuantity;
        }
        public void SubtractQuantity(int p_storeId, int p_productId, int p_quantity)
        {
            string sqlQuery = @"Update Inventory 
                                set Quantity = Quantity - @Quantity 
                               WHERE  StoreID = @StoreID and ProductID = @ProductID ";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_storeId);
                command.Parameters.AddWithValue("@ProductID", p_productId);
                command.Parameters.AddWithValue("@Quantity", p_quantity);
               command.ExecuteNonQuery();
            }
        }
        public void CartQuantity( int p_storeId, int p_productId ,int p_quantity)
         {   
            string sqlQuery= @"SELECT MAX(Quantity) - MIN(Quantity) AS 'Placed quantity' FROM Inventory   where StoreID = @StoreID and ProductID = @ProductID ";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
               SqlCommand command = new SqlCommand(sqlQuery, con);
               command.Parameters.AddWithValue("@StoreID", p_storeId);
                command.Parameters.AddWithValue("@ProductID", p_productId);
                command.Parameters.AddWithValue("@Quantity", p_quantity);
                SqlDataReader reader = command.ExecuteReader();
                command.ExecuteNonQuery();
            }
        }

        public List<Products> GetAllProductByStoreId(int p_storeId)
        {
            string sqlQuery =@"select DISTINCT  p.ProductID , p.ProductName ,p.Price ,p.Description ,p.Category 
                                from Products p , Inventory i 
                                Where p.ProductID  = i.ProductID 
                                and i.StoreID = @P_storeId";
            List<Products> listProduct = new List<Products>();
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery , con);
                command.Parameters.AddWithValue("@P_storeId" , p_storeId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listProduct.Add( new Products ()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price  = reader.GetInt32(2),
                        Description = reader.GetString(3),
                        Category = reader.GetString(4)
                    });  
                }
            }
            return listProduct;

        }
    }
}