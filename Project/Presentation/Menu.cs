static class Menu
{
    public static string message = "";
    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.Clear();
        if (message != "") Console.WriteLine(message + "\n");
        message = "";
        Console.WriteLine("Enter 1 to login");
        Console.WriteLine("Enter 2 to create an account");
        Console.WriteLine("Enter 3 to see the menu card");
        Console.WriteLine("Enter 4 to exit the program");

        string input = Console.ReadLine() ?? "";
        if (input == "1")
        {
            UserLogin.Start();
        }
        else if (input == "2")
        {
            UserLogin.CreateAccount();
        }
        else if (input == "3")
        {
            MenuCard.ShowMenuCard();
        }
        else if (input == "4")
        {
            System.Environment.Exit(0);
        }
        else
        {
            message = "Invalid input";
            Console.Clear();
            Start();
        }

    }
}
