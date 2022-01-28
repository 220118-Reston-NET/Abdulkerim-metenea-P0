using storeModel;
namespace storeDL
{
    /// <summary>
    /// Data layer Responsible interacting with store database and doing CRUD operation
    /// C-creat, R-Read, U-Update,D-Delete
    /// </summary>
    public interface IRepository 
    {
        /// <summary>
        /// Add customer to the database
        /// </summary>
        /// <param name="p_Cust"> this is Customer Object Adding to the database</param>
        /// <returns>Retun the customer that was Added</returns>
        Customer AddCustomer(Customer p_Cust);
        /// <summary>
        /// all Customer will here
        /// </summary>
        /// <returns>Retuns a List of Collection of Customer Objects</returns>
        List<Customer> GetAllCustomer();
    }
}
