
// using System.Linq;
using storeDL;
using storeModel;
namespace storeBL
{
    public class CustomerBL : ICustomerBL
    {
        //Dependency Injection Pattern
        private CustSQLRepo _repo;
        public CustomerBL(CustSQLRepo p_repo)
        {
            _repo = p_repo;
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> ListOfCustomer = _repo.GetAllCustomer();
            return ListOfCustomer;
        }
        public Customer AddCustomer(Customer p_Cust)
        {
            List<Customer> ListOfCustomer = _repo.GetAllCustomer();
            if (ListOfCustomer.Contains(p_Cust) == false)
            {
                return _repo.AddCustomer(p_Cust);
            }
            else
            {
                throw new Exception("you Alrady registord!");
            }
            
        }
        public List<Customer> SearchCustomer(String name)
        {
            return _repo.SearchCustomer(name);
            // List<Customer> ListOfCustomer = _repo.GetAllCustomer();
            // return ListOfCustomer
            // .Where(Customer => Customer.CustName.Contains(name))
            // .ToList();
        }
        // public List<Orders> OrderHistoryByCustID(int p_CustID)
        // {
        //     return _repo.OrderHistoryByCustID(p_CustID);
        // }
        // public List<Orders> ListOfOrders()
        // {
        //     List<Orders> ListOfOrders = _repo.GetAllOrders();
        //     return ListOfOrders;
        // }
        public Customer GetCustomerByCustID(int p_CustID)
        {
            return _repo.GetAllCustomer().Where(p=>p.CustID == p_CustID).First();
        }
    }
}