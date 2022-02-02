using storeBL;
using storeModel;
namespace storeUI
{
    public class AddCustomerMenu : IMenu
    {   
         private static Customer _newCust = new Customer();
        private ICustomerBL _CustBL ;
        public AddCustomerMenu(ICustomerBL p_CustBL)
        {
            _CustBL = p_CustBL;

        }
        public void Display()
        {
            Console.WriteLine("Enter Customer information");
            Console.WriteLine("[2] Name - " + _newCust.CustName);
            Console.WriteLine("[3] Address - " + _newCust.CustAddress);
            Console.WriteLine("[4] Phone- " + _newCust.CustPhoneNumber);
            Console.WriteLine("[1] Save" );
            Console.WriteLine("[0] Go Back to mainMennu");
        }  

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1": 
                    try
                    {
                        Log.Information("Adding Customer \n" + _newCust);
                        _CustBL.AddCustomer(_newCust);
                        Log.Information("Successful adding Customer");
                        // Console.WriteLine("Customer Add scucessfully!");
                        // return "AddOrders";
                        return "MainMenu";
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Faild to Adding Customer Trying a agin later!");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();            
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter Customer Name!");
                    _newCust.CustName = Console.ReadLine();
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Please enter Customer Address!");
                    _newCust.CustAddress = Console.ReadLine();
                    return "AddCustomer";
                case "4":
                    Console.WriteLine("Please enter Customer Email or Phone!");
                    _newCust.CustPhoneNumber = Console.ReadLine();
                    return "AddCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Addcustomer";
            }
        }
    }
}