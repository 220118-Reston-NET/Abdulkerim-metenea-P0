using storeDL;
using storeModel;
namespace storeBL
{
    public class CustomerBL : ICustomerBL
    {
        //Dependency Injection Pattern
        // uses save time re-writing code that breaks if you update a complete separet Class.
        //=======
        private IRepository _repo;
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;

        }
        //=========
        public Customer AddCustomer(Customer p_Cust)
        {
            Random rand = new Random();
           p_Cust.EmailPhoneNumber  += rand.Next(0,10);

            List<Customer> ListOfCustomer = _repo.GetAllCustomer();
            if(ListOfCustomer.Count < 10)
            {
                return _repo.AddCustomer(p_Cust);
            }
            else
            {
                throw new Exception("you can't order More Than 10 orders");
            }
        }
        public List<Customer> SearchCustomer(String p_name)
        {
            List<Customer> ListOfCustomer = _repo.GetAllCustomer();
           //LINQ library   
           //Where:- method is designed tocollection based on a condition
           //ToList :- method converts to a list collection
            return ListOfCustomer
            .Where(customer => customer.Name.Contains(p_name))
            .ToList();
        }
    }
}