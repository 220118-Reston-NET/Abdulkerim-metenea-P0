
namespace storeModel
{
    public class Orders
    {   
        public int OrderID {get;set;}
        public int CustID { get; set; }
        public int StoreID { get; set; }
        public int TotalPrice{get;set;}
        public List<LineItems> LineItems{get;set;}
        
        public Orders()
        {
            CustID = 0;
            StoreID = 0;
            TotalPrice = 0;
            LineItems = new List<LineItems>(){new LineItems() };
        }
        public override string ToString()
        {
            return $"OrderID: {OrderID}\nStoreID: {StoreID}\nCustID: {CustID}\nTotalPrice: {TotalPrice}";
        }
         
    }
    
}