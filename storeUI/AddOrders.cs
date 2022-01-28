using storeModel;

namespace storeUI
{
    public class AddOrders : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        public static Orders _newOrder = new Orders();
        public void Display()
        {
            Console.WriteLine("Enter Order information");
            Console.WriteLine("[6] StoreAddress - " + _newOrder.storeAddress);
            Console.WriteLine("[7] TotalPrice - " + _newOrder.TotalPrice);
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
                    return "MainMenu";
                case "9":
                    return "AddOrders";

                case "6":
                    Console.WriteLine("Please enter Store Address!");
                    _newOrder.storeAddress = Console.ReadLine();
                    return "AddOrder";
                case "7":
                    Console.WriteLine("Please enter Totalprice!");
                    // _newCustomer.Address = Convert.ToInt32(Console.ReadLine());
                    _newOrder.TotalPrice = Convert.ToInt32(Console.ReadLine());
                    return "AddOrder";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddOrders";
            }
        }
    }
}