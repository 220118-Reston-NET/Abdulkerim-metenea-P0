namespace storeModel
{
    public class LineItems 
    {
        public LineItems(string _products, int _quantity)
        {
            Products = _products;
            Quantity = _quantity;

        }
        public string Products { get; set; }
        public int Quantity { get; set; }
        public LineItems()
        {
            Products = "Orange";
            Quantity = 100;

        }
    }


}