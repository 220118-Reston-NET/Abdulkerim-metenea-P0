using System.Text.Json;
using storeModel;

namespace storeDL
{                     // This Repo was just For Json
    public class Repository 
    {
        private string _filepath = "../storeDL/Database/";
        private string _jsonString;
        public Customer AddCustomer(Customer p_Cust)
        {
            string path = _filepath + "Customer.json";
            List<Customer> ListOfCustomer = GetAllCustomer();
            ListOfCustomer.Add(p_Cust);
            _jsonString = JsonSerializer.Serialize(ListOfCustomer, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(path, _jsonString);
            return p_Cust;
        }
        public List<Customer> GetAllCustomer()
        {
            //Grab information from the json file and stores in string
            _jsonString = File.ReadAllText(_filepath + "Customer.json");
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        // public List<Orders> GetAllOrders()
        // {
        //     throw new NotImplementedException();
        // }

        // public List<Orders> OrderHistoryByCustID(int p_CustId)
        // {
        //     throw new NotImplementedException();
        // }
    }
}