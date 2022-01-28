
namespace storeUI
{
    public interface IMenu
    {
        /// <summary>
        /// Will display the menu the customer what they need
        /// </summary>
        void Display();

        /// <summary>
        /// Will record the user's choice what they need
        /// </summary>
        /// <returns>Return the menu that will change your screen</returns>
        
        string UserChoice();
        
    }
}