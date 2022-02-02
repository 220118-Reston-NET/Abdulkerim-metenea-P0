
// using System.Linq;
using storeDL;
using storeModel;
namespace storeBL
{
    public class CustomerBL : ICustomerBL
    {
        //Dependency Injection Pattern
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;

        }
        public Customer AddCustomer(Customer p_Cust)
        {
            //     Random rand = new Random();
            //    p_Cust.EmailPhoneNumber  += rand.Next(0,10);

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
        public List<Customer> SearchCustomer(String p_CustName)
        {
            List<Customer> ListOfCustomer = _repo.GetAllCustomer();
            return ListOfCustomer
            .Where(Customer => Customer.CustName.Contains(p_CustName))
            .ToList();
        }
    }
}