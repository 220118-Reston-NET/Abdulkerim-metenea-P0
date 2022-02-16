using System.Data.SqlClient;
using storeModel;

namespace storeDL
{
    public class LineItemSQLRepo : ILineItemIRepo
    {
        private readonly string _connectionString;
        public LineItemSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public List<LineItems> GetAllLineItemsByOrderID(int p_OrderID)
        {
            List<LineItems> Items = new List<LineItems>();
            string sqlQuery = @"Select * from LineItems li
            inner join Orders o on li.OrderID= o.OrderID Where o.OrderID = @OrderID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@OrderID", p_OrderID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Items.Add(new LineItems()
                    {
                        OrderID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        Quantity = reader.GetInt32(2),
                    });
                }
            }

            return Items;
        }
        public List<LineItems> GetAllineItems()
        {
            List<LineItems> ListItems = new List<LineItems>();
            string sqlQuery = @"select * from LineItems";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListItems.Add(new LineItems()
                    {
                        OrderID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        Quantity = reader.GetInt32(2)

                    });
                }
            }

            return ListItems;
        }
        public List<LineItems> ReduceQuantity(int productId, int quantity)
        {
            List<LineItems> ListOfineItems = new List<LineItems>();
            string sqlQuery = @" Update LineItems set Quantity = Quantity - @Quantity where ProductID = @ProductID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("ProductID", productId);
                command.Parameters.AddWithValue("Quantity", quantity);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListOfineItems.Add(new LineItems()
                    {
                        OrderID = reader.GetInt32(0),
                        ProductID = reader.GetInt32(1),
                        Quantity = reader.GetInt32(2)

                    });
                }
            }

            return ListOfineItems;
        }
        // public List<LineItems> GetAllLineItemsByOrderID(int p_OrderID)
        // {
        //     List<LineItems> ItemOrderd = new List<LineItems>();
        //     List<Products> OrderdProduct = new List<Products>();
        //     string sqlQuery = @"Select li.OrderID, li.ProductID, p.ProductName, p.Price , li.Quantity From LineItems li
        //     inner join Products p on li.ProductID = p.ProductID
        //     Where li.OrderID = @OrderID";
        //     using(SqlConnection con = new SqlConnection(_connectionString))
        //     {
        //         con.Open();
        //      SqlCommand command = new SqlCommand(sqlQuery, con);
        //      command.Parameters.AddWithValue("@OrderID", p_OrderID);
        //      SqlDataReader reader = command.ExecuteReader();
        //      while (reader.Read())
        //      {
                   
        //                 ItemOrderd.Add(new LineItems ()
        //                 {
        //                    OrderID = reader.GetInt32(0),
        //                    ProductID = reader.GetInt32(1),
        //                    Quantity = reader.GetInt32(4)

        //                 });
        //             OrderdProduct.Add(new Products ()
        //             {
        //                 ProductName = reader.GetString(2),
        //                 Price = reader.GetInt32(3)

        //             });
        //         }
        //     }
        // }
    }
}