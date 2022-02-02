
namespace storeModel
{
    public class Orders
    {   
        public int OrderID {get;set;}
        public string storeAddress {get;set;}
        public int TotalPrice{get;set;}
        public List<LineItems> LineItems{get;set;}
        public Orders()
        {   
            OrderID = 001;
            storeAddress = "3340 st CA"; //where Customer orders
            TotalPrice = 0;
            LineItems = new List<LineItems>(){new LineItems() };
        }
         
    }
    
}