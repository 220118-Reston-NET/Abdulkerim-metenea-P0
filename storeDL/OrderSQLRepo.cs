using System.Data.SqlClient;
using storeModel;

namespace storeDL
{
    public class OrderSQLRepo : IOrderRepo
    {
        private readonly string _connectionString;
        public OrderSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        private StoreFrontSQLRepo storerepo;
        public List<Orders> GetAllOrders()
        {
            List<Orders> ListOfOrders = new List<Orders>();
            string sqlQuery = @"select * from Orders";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListOfOrders.Add(new Orders()
                    {
                        OrderID = reader.GetInt32(0),
                        CustID = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        TotalPrice = reader.GetInt32(3) 
                    });
                }
            }
            return ListOfOrders;
        }
        public List<Orders> OrderHistoryByCustID(int P_CustID)
        {
            List<Orders> ListOfOrders = new List<Orders>();
            string sqlQuery = @"select * from Orders where CustID = @CustID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CustID", P_CustID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListOfOrders.Add(new Orders()
                    {
                        OrderID = reader.GetInt32(0),
                        CustID = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        TotalPrice = reader.GetInt32(3),
                        LineItems = new List<LineItems>(reader.GetInt32(0))
                    });
                }
            }
            return ListOfOrders;
        }
        public List<Orders> GetAllOrdersByStorID(int p_StoreID)
        {
            List<Orders> ListOrders = new List<Orders>();
            // List<StoreFront> ListStores = new List<StoreFront>();
            string sqlQuery = @"select o.Order, o.CustID, o.StoreID , o.StoreID from Orders o
            inner join StoreFront sf on o.StoreID = sf.StoreID where o.StoreID = @StoreID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_StoreID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListOrders.Add(new Orders()
                    {
                        OrderID = reader.GetInt32(0),
                        CustID = reader.GetInt32(1),
                        StoreID = reader.GetInt32(2),
                        TotalPrice = reader.GetInt32(3),
                        LineItems = new List<LineItems>(reader.GetInt32(0))
                    });
                    
                }
            }
            return ListOrders;
        }
        public void PlaceOrder(int p_custId, int p_storeId, int p_totalprice, List<LineItems> p_cart)
        {
            
            string OrdersqlQuery = @"insert into Orders values(@CustID,@StoreID,@TotalPrice); select scope_Identity();";
            string ItemsqlQuery = @"insert into LineItems values(@OrderID,@ProductID,@Quantity)";
            storerepo = new StoreFrontSQLRepo(_connectionString);

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(OrdersqlQuery, con);
                command.Parameters.AddWithValue("@CustID", p_custId);
                command.Parameters.AddWithValue("@StoreID", p_storeId);
                command.Parameters.AddWithValue("@TotalPrice", p_totalprice);
                int OrderID = Convert.ToInt32(command.ExecuteScalar());

                
                foreach (var item in p_cart)
                {
                    SqlCommand command2 = new SqlCommand(ItemsqlQuery, con);
                    command2.Parameters.AddWithValue("@OrderID", OrderID);
                    command2.Parameters.AddWithValue("@ProductID", item.ProductID);
                    command2.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command2.ExecuteNonQuery();
                    storerepo.SubtractQuantity(p_storeId,item.ProductID, item.Quantity);
                    
                }
                
                
            } 
            
        }
           
    }
}