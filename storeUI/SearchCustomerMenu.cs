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
            Console.WriteLine("please Press 2 And check by your Name");
            Console.WriteLine("[2] Check by Name");
            Console.WriteLine("[0] Go Back");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "2":
                     //apply to Grap user Input
                    Console.WriteLine("please Enter Your Name");
                    string name = Console.ReadLine();
                    // string pastorder = Console.ReadLine();
                    List<Customer> listOfCustomer = _CustBL.SearchCustomer(name);
                    // List<Orders> ListOfOrders = _CustBL.SearchOrders(pastorder);
                    // bool true = listOfCustomer.Contains(CustName);
                    // if(true)
                    // {
                        // foreach (var item in listOfCustomer)
                        // {
                        //     Console.WriteLine("************");
                        //     Console.WriteLine(item);
                        // }
                    // }
                    // else
                    // {
                    //     Console.WriteLine("Customer hasn't Registord please add you information");
                    //     return "MainMenu";
                    // }
                    foreach (var item in listOfCustomer)
                    {
                        Console.WriteLine("************");
                        Console.WriteLine(item);
                        // foreach( var orderhistory in ListOfOrders)
                        // {
                        //     Console.WriteLine(orderhistory);
                        // }
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
