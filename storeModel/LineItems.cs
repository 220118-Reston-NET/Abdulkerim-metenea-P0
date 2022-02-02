namespace storeModel
{
    public class LineItems 
    {   
        public int ProductID {get;set;}
        public string ProductName {get;set;}
        public int Quantity { get; set; }
        public LineItems()
        {   
            ProductID = 01;
            ProductName = "Orange";
            Quantity = 10;
        }
    }


}