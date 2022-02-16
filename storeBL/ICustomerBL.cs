using storeModel;
namespace storeBL
{ 
    public interface ICustomerBL
    {
        Customer AddCustomer(Customer P_Cust);
        List<Customer> GetAllCustomer();
        List<Customer>  SearchCustomer(string name);
        
       

    }
}

