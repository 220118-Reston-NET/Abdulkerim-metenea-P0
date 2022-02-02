
// using System.Linq;
using storeDL;
using storeModel;
namespace storeBL
{
    public class StoreFrontBL : IStoreFrontBL 
    {
        //Dependency Injection Pattern
        private IStoreRepository _repo;
        public StoreFrontBL(IStoreRepository p_repo)
        {
            _repo = p_repo;

        }
        public StoreFront PlaceOrder(StoreFront p_name)
        {
            //     Random rand = new Random();
            //    p_Cust.EmailPhoneNumber  += rand.Next(0,10);

            List<StoreFront> ListOfStore = _repo.GetAllStoreFront();
            if (ListOfStore.Contains(p_name) == true)
            {
                return _repo.PlaceOrder(p_name);
            }
            else
            {
                throw new Exception("Wrong Store Name!");
            }
        }
        public List<StoreFront> ListStore(String p_StoreName)
        {
            List<StoreFront> ListOfStore = _repo.GetAllStoreFront();
            return ListOfStore
            .Where(StoreFront => StoreFront.StoreName.Contains(p_StoreName))
            .ToList();
        }
    }
}