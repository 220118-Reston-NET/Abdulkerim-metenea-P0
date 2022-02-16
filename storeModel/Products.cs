
namespace storeModel
{
    public class Products
    { 
        public int ProductID {get;set;}
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? Category  { get; set; }
        public  Products()
        {     
            ProductName = " Water";
            Price =0;
            Description = "Package";
            Category = "Beverage";
        }

        public override string ToString()
        {
            return $"ProductID: {ProductID}\nProductName: {ProductName}\nPrice:{Price}\nDescription: {Description}\nCategory: {Category}";
        }
    }

    
}


























