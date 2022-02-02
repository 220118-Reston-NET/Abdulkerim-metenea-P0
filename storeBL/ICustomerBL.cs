using storeModel;
namespace storeBL
{ 
    /// <summary>
    /// Processing data obtained from either Database or the user
    /// all depends the type of functionality
    /// </summary>
    public interface ICustomerBL
    {
        /// <summary>
        /// will add Customer data to the database
        /// </summary>
        /// <param name="p_Cust"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer p_Cust);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_CustName"></param>
        /// <returns> filterd list of Customer</returns>
        List<Customer>  SearchCustomer(string p_CustName);

    }
}

