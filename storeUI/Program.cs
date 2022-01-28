// See https://aka.ms/new-console-template for more information
global using Serilog;
using storeBL;
using storeDL;
using storeUI;


//Creating and Configuring our Logger
Log.Logger = new LoggerConfiguration()
        .WriteTo.File("./logs/user.txt")
        .CreateLogger();

bool repeat = true;
IMenu menu = new MainMenu();

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "searchCustomer":
            Log.Information("Displaying searchCustomer Menu to user");
            menu = new SearchCustomerMenu(new CustomerBL(new Repository()));
            break;
        case "AddCustomer":
            Log.Information("Displaying AddCustomer Menu to user");
            menu = new AddCustomerMenu(new CustomerBL(new Repository()));
            break;
        case "MainMenu":
            Log.Information("Displaying MainMenu to user");
            menu = new MainMenu();
            break;
        case "Exit":
            Log.Information("Exit Application");
            Log.CloseAndFlush();
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            Console.WriteLine("Press Enter To continue");
            Console.ReadLine();
            break;
    }
}
