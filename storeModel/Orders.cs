
namespace storeModel
{
    public class Orders
    {
        public string storeAddress {get;set;}
        public int _totalPrice ;
        public int TotalPrice
        {
            get {return _totalPrice;}
            set{
                if (value < 1000 )
                {
                    _totalPrice = value;
                }
                else
                {
                    throw new Exception("you can not order More Than $1000");
                }
            }

        }
        private List<LineItems> _items;
        public List<LineItems> LineItems
        {
            get{return _items;}
            set {_items = value;}
        }
        public Orders()
        {   
            storeAddress = "3340 st CA";
            TotalPrice = 0;
            _items = new List<LineItems>()
            {
                 new LineItems()
            };

        }
        
       
    }
    
}