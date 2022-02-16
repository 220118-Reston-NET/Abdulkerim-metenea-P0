
using storeDL;
using storeModel;
namespace storeBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private StoreFrontSQLRepo _repo;
        public StoreFrontBL(StoreFrontSQLRepo p_repo)
        {
            _repo = p_repo;

        }
        public List<StoreFront> GetAllStoreFront()
        {
            List<StoreFront> ListOfStores = _repo.GetAllStoreFront();
            return ListOfStores;
        }
        public StoreFront AddStoreFront(StoreFront p_store)
        {
            List<StoreFront> ListOfStoreFront = _repo.GetAllStoreFront();
            if (ListOfStoreFront.Contains(p_store) == false)
            {
                return _repo.AddStoreFront(p_store);
            }
            else
            {
                throw new Exception("Store Already Existe!");
            }

        }
        public List<StoreFront> ViewInventory(String p_storeName)
        {
            List<StoreFront> ListOfStores = _repo.GetAllStoreFront();
            return ListOfStores
            .Where(Store => Store.StoreName.Contains(p_storeName))
            .ToList();
        }

        public List<StoreFront> ViewStoreFront(int P_StoreID)
        {
            List<StoreFront> ListOfStores = _repo.GetAllStoreFront();
            return ListOfStores
            .Where(Store => Store.StoreID == P_StoreID)
            .ToList();
        }

        public List<Inventory> GetAllInventoryBYStoreId(int p_storeId)
        {
            List<Inventory> inventory = _repo.GetAllInventory();
            return inventory
            .Where(inv => inv.StoreID == p_storeId)
            .ToList();
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> ListOfInventory = _repo.GetAllInventory();
            return ListOfInventory;
            
        }
        public List<Inventory> AddProductQuantity(int p_storeId, int p_productId, int p_quantity)
        {    
            return  _repo.AddProductQuantity(p_storeId ,p_productId ,p_quantity);
            
        }

        public void SubtractQuantity(int p_storeId, int p_productId, int p_quantity)
        {
          _repo.SubtractQuantity(p_storeId, p_productId, p_quantity);
        }

        public List<Products> GetAllProductByStoreId(int p_storeId)
        {
            return _repo.GetAllProductByStoreId(p_storeId);
        }
    }
}