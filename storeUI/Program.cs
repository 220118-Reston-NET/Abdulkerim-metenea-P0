// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// using STOREAPP;
// using storeModel;
using storeUI;


// Order ord = new Order();
// ord.items = 21; //Validation 

bool repeat = true;
userMenu menu = new MainMenu();

while (repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "Products":
            menu = new Products();
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "Exit":
            repeat = false;
            break;
        default:
            Console.WriteLine("Page does not exist!");
            break;
    }
}
