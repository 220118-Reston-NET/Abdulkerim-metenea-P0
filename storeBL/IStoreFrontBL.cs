using storeModel;
namespace storeBL
{
    public interface IStoreFrontBL
    {
        List<StoreFront> ViewStoreFront(int P_StoreID);
        List<StoreFront> ViewInventory(String p_storeName);
        List<StoreFront> GetAllStoreFront();
        StoreFront AddStoreFront(StoreFront p_store);
        List<Inventory> GetAllInventoryBYStoreId(int p_storeId);
        List<Inventory> GetAllInventory();
        List<Inventory> AddProductQuantity(int p_storeId, int p_productId, int p_quantity);
        void SubtractQuantity(int p_storeId, int p_productId, int p_quantity);
        List<Products> GetAllProductByStoreId(int p_storeId);
        
    }
}