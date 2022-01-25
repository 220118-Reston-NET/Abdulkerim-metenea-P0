
// using STOREAPP;
using storeModel;
namespace storeUI
{
    public class Products : userMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddPokeMenu
        public static Customer _newCustomer = new Customer();
        public void Display()
        {
            Console.WriteLine("Enter Customer information");
            Console.WriteLine("[0] Orders - " + _newCustomer.Orders);
            Console.WriteLine("[1] Name - " + _newCustomer.Name);
            Console.WriteLine("[2] Address - " + _newCustomer.Address);
            Console.WriteLine("[3] EmailPhoneNumber - " + _newCustomer.EmailPhoneNumber);
            Console.WriteLine("[4] Save");
            Console.WriteLine("[5] Go Back Menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Console.WriteLine("Please enter Products!");
                    // _newCustomer.Orders = Console.ReadLine();
                    return "Products";
                case "1":
                    Console.WriteLine("Please enter Email or phoneNumber!");
                    _newCustomer.EmailPhoneNumber = Console.ReadLine();
                    return "Products";
                case "2":
                    Console.WriteLine("Please enter Address!");
                    _newCustomer.Address = Console.ReadLine();
                    return "Products";
                case "3":
                    Console.WriteLine("Please enter a name!");
                    _newCustomer.Name = Console.ReadLine();
                    return "Products";
                case "4":
                    return "MainMenu";
                case "5":
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Products";
            }
        }

        public string Desc
        {
            get { return Desc; }
        }
        public string Catagory
        {
            get
            {
                return Catagory;
            }
        }
    }
}