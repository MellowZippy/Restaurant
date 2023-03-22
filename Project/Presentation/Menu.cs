static class Menu
{

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.WriteLine("Enter 1 to login");
        Console.WriteLine("Enter 2 to view all available food products");

        string input = Console.ReadLine()!;
        if (input == "1")
        {
            UserLogin.Start();
        }
        else if (input == "2")
        {
            MenuCard.ShowMenuCard();
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }

    }
}