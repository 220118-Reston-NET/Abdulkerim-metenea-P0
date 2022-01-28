using storeBL;
using storeModel;
namespace storeUI
{
        public class SearchCustomerMenu : IMenu
    {
        private ICustomerBL _CustBL;
        public SearchCustomerMenu(ICustomerBL p_CustBL)
        {
            _CustBL = p_CustBL;
        }
        public void Display()
        {
            Console.WriteLine("select an option to check If you're Already In Customer Database");
            Console.WriteLine("[1] by Phone");
            Console.WriteLine("[9] Add Orders");
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
                     //apply to Grap user Input
                    Console.WriteLine("please Enter a Phone Number");
                    string name = Console.ReadLine();
                    //Apply Display The Reasult
                    List<Customer> ListOfCustomer = _CustBL.SearchCustomer(name);
                    foreach (var item in ListOfCustomer)
                    {
                       Console.WriteLine("************");
                       Console.WriteLine("item");
                    }
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return "MainMenu";
                // case "9":
                //     return "addOrder";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchCustomer";
            }
        }
    }
}
