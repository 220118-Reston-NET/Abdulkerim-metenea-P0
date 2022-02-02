
namespace storeModel
{
    public class Products
    { 
        public int ProductID {get;set;}
        public string ProductName { get; set; }
        public double price { get; set; }
        public string Desc { get; set; }
        public string Category  { get; set; }

        public  Products()
        {     
            ProductID =001;
            ProductName = " Water";
            price = 4.00;
            Desc = "Package";
            Category = "Beverage";
        }
        
    }
}


























