using storeModel;
namespace storeBL
{
   /// <summary>
   /// 
   /// </summary>
    public interface IStoreFrontBL
    {
        /// <summary>
        /// will add Customer data to the database
        /// </summary>
        /// <param name="p_item"></param>
        /// <returns></returns>
        StoreFront PlaceOrder(StoreFront p_item);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_StoreName"></param>
        /// <returns></returns>
        List<StoreFront> SearchStore(string p_StoreName);

    }
}