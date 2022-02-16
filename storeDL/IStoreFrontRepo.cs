using storeModel;

namespace storeDL
{
    /// <summary>
    /// Data layer Responsible interacting with store database and doing CRUD operation
    /// C-creat, R-Read, U-Update,D-Delete
    /// </summary>
    public interface IStoreFrontRepo
    {
        StoreFront AddStoreFront(StoreFront p_store);
        List<StoreFront> GetAllStoreFront();
        List<Inventory> AddProductQuantity(int p_storeId, int p_productId, int p_quantity);
        void SubtractQuantity(int p_storeId, int p_productId, int p_quantity);
        List<Products> GetAllProductByStoreId(int p_storeId);
    }

}
