using System.Text.Json;
using storeModel;
namespace storeDL
{
    public class StoreRepository : IStoreRepository
    {
        private string _filepath = "../storeDL/Database/";
        private string _jsonString;
        public StoreFront PlaceOrder(StoreFront p_item)
        {
            string path = _filepath + "StoreFront.json";
            List<StoreFront> ListOfStore = GetAllStoreFront();
            ListOfStore.Add(p_item);
            _jsonString = JsonSerializer.Serialize(ListOfStore, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(path, _jsonString);
            return p_item;

        }
        public List<StoreFront> GetAllStoreFront()
        {
            //Grab information from the json file and stores in string
            _jsonString = File.ReadAllText(_filepath + "storeFront.json");
            return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
        }
    }
}