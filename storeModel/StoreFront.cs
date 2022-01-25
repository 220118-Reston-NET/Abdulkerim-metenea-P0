
namespace storeModel
{
    public class StoreFront
    {
        private string _Name;
        public string _Address;
        public string Orders;
        public string Name
        {
            get { return Name; }

        }
        public string Address
        {
            get { return Address; }
            set { Address = value; }
        }
        public List<Products> Products
        {
            get { return Products; }
            set
            {
                if (value.Count > 10)
                {
                    Products = value;
                }
                else
                {
                    throw new Exception("Sorry Out of Store!");
                }
            }
        }
    }
}