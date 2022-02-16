using System.Data.SqlClient;
using storeModel;

namespace storeDL
{
    public class CustSQLRepo : ICustRepo
    {
        private readonly string _connectionString;
        public CustSQLRepo(string p_connectionString)
        {
            _connectionString = p_connectionString;
        }
        public Customer AddCustomer(Customer p_Cust)
        {
            string sqlQuery = @"insert into Customer 
                            values(@CustName, @CustAddress, @CustPhone)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CustName", p_Cust.CustName);
                command.Parameters.AddWithValue("@CustAddress", p_Cust.CustAddress);
                command.Parameters.AddWithValue("@CustPhone", p_Cust.CustPhone);

                command.ExecuteNonQuery();
            }

            return p_Cust;
        }
        public List<Customer> GetGetCustomerByCustID(int p_CustID)
        {
            List<Customer> Cust = new List<Customer>();
            string sqlQuery = @"select * from Customer where CustID = @CustID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CustID", p_CustID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cust.Add(new Customer()
                    {
                        CustID = reader.GetInt32(0),
                        CustName = reader.GetString(1),
                        CustAddress = reader.GetString(2),
                        CustPhone = reader.GetString(3)
                    });
                }
            }

            return Cust;
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> ListOfCustomer = new List<Customer>();
            string sqlQuery = @"select * from Customer";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListOfCustomer.Add(new Customer()
                    {
                        CustID = reader.GetInt32(0),
                        CustName = reader.GetString(1),
                        CustAddress = reader.GetString(2),
                        CustPhone = reader.GetString(3),
                        Orders = new List<Orders>(reader.GetInt32(0))
                    });
                }
            }

            return ListOfCustomer;
        }
        public List<Customer> SearchCustomer(string name)
        {
            List<Customer> P_Cust = new List<Customer>();
            string sqlQuery = @"Select * From Customer Where CustName = @CustName";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CustName", name);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    P_Cust.Add(new Customer()
                    {
                        CustID = reader.GetInt32(0),
                        CustName = reader.GetString(1),
                        CustAddress = reader.GetString(2),
                        CustPhone = reader.GetString(3)
                    });
                }
            }

            return P_Cust;
        }
        // public Customer UpdateCustomer(Customer p_Cust)
        // {
        //     string sqlQuery = @"Update Customer 
        //                     set CustName= @CustName, CustAddress= @CustAddress, CustPhone = @CustPhone)";
        //     using (SqlConnection con = new SqlConnection(_connectionString))
        //     {
        //         con.Open();
        //         SqlCommand command = new SqlCommand(sqlQuery, con);
        //         command.Parameters.AddWithValue("@CustName", p_Cust.CustName);
        //         command.Parameters.AddWithValue("@CustAddress", p_Cust.CustAddress);
        //         command.Parameters.AddWithValue("@CustPhone", p_Cust.CustPhone);

        //         command.ExecuteNonQuery();
        //     }

        //     return p_Cust;
        // }

    }
}