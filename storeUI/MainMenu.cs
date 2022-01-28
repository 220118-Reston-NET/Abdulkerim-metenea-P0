namespace storeUI
{
    //MainMenu inherits userMenu interface
    public class MainMenu : IMenu 
    {
        public void Display()
        {
            Console.WriteLine("Welcome to Our Store!");
            Console.WriteLine("What would you like to Order?");
            Console.WriteLine("[2] check a Customer");
            Console.WriteLine("[1] Add Customer");
            Console.WriteLine("[9] Add Order");
            Console.WriteLine("[0] Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases are just useful if you are doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "AddCustomer";
                case "2":
                    return "SearchCustomer";
                case "9":
                    return "Addorder";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}
