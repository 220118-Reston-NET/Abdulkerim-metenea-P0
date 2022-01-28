
namespace storeModel
{
    public class StoreFront
    {
        private string _name;
        private string _address;
        public List<string> Products = new List<string>();
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
        public string StorAddress
        {
            get { return _address; }
            set { _address = value; }
        }
        public List<string> Orders = new List<string>();
         public List<string>CustOrders()
         {
           return Orders;
       
         }
    }
}