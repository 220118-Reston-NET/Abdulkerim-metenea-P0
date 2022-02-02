using storeModel;

namespace storeUI
{
    public class PlaceOrderMenu : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        public static StoreFront ListStores = new StoreFront();
        private IStoreFrontBL _storeFrontBL;
        public PlaceOrderMenu(IStoreFrontBL p_StorFrontBL)
        {
            _storeFrontBL = p_StorFrontBL;

        }
        public void DisplayStores()
        {   ListStores = _storeFrontBL.GetAllStoreFront();
            Console.WriteLine("Enter Order information");
            Console.WriteLine("[2] StoreName - " + ListStores.StoreName);
            Console.WriteLine("[3] StoreAddress - " + ListStores.StoreAddress);
            Console.WriteLine("[4] TotalPrice - " + ListStores.Products);
            Console.WriteLine("[1] Save");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Log.Information("PlaceOrders \n" + ListStores);
                    _storeFrontBL.AddOrders(ListStores);
                    Log.Information("you Order is Successful ");
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Store Name!");
                    _storeFrontBL.StoreName = Console.ReadLine();
                    return "PlaceOrder";

                case "3":
                    Console.WriteLine("Store Address!");
                    _storeFrontBL.StoreAddress = Console.ReadLine();
                    return "PlaceOrder";
                case "4":
                    Console.WriteLine("Product Items!");
                    // _newCustomer.Address = Convert.ToInt32(Console.ReadLine());
                    _storeFrontBL.Products = Console.ReadLine();
                    return "PlaceOrder";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}