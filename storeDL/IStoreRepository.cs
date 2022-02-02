using storeModel;
namespace storeDL
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStoreRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_item"></param>
        /// <returns></returns>
        StoreFront PlaceOrder(StoreFront p_item);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<StoreFront> GetAllStoreFront();
    }
}