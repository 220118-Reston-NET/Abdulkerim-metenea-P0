using storeModel;

namespace storeDL
{
    /// <summary>
    /// Data layer Responsible interacting with store database and doing CRUD operation
    /// C-creat, R-Read, U-Update,D-Delete
    /// </summary>
    public interface ICustRepo
    {
        Customer AddCustomer(Customer p_Cust);
        List<Customer> SearchCustomer(string name);
        List<Customer> GetAllCustomer();
    }
}