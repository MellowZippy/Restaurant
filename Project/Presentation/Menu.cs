static class Menu
{
    public static string message = "";

    public static void Print()
    {
        if (message != "") Console.WriteLine(message + "\n"); message = "";
    }
    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void AdminUI()
    {
        Console.WriteLine("Enter 1 to see all reservations");
        Console.WriteLine("Enter 2 to see Menu");
        Console.WriteLine("Enter 3 to change the Menu");
        Console.WriteLine("Enter 4 to change Restaurant Layout");
        Console.WriteLine("Enter 5 to change Restaurant Information");
        Console.WriteLine("Enter 6 to Quit");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            //Method to see all Reservation
        }
        else if (input == "2")
        {
            MenuCard.ShowMenuCard();
        }
        else if (input == "3")
        {
            //Method to change Menu
        }
        else if (input == "4")
        {
            //Method to change Restaurant layout
        }
        else if (input == "5")
        {
            //Method to change Restaurant Information
        }
        else if (input == "6")
        {
            System.Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Invalid input");
            Menu.AdminUI();
        }
    }

    static public void UserUI()
    {
        Console.WriteLine("Enter 1 to see your Reservation");
        Console.WriteLine("Enter 2 to make your Reservation");
        Console.WriteLine("Enter 3 to change your Reservation");
        Console.WriteLine("Enter 4 to remove your Reservation");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            //Method to see all reservation
        }
        else if (input == "2")
        {
            //Method to make your reservation
        }
        else if (input == "3")
        {
            //Method to change your reservation
        }
        else if (input == "4")
        {
            //Method to remove your reservation
        }
        Console.WriteLine("Invalid input");
        Menu.AdminUI();

    }

    static public void WaiterUI()
    {
        Console.WriteLine("hello waiter");
    }

    static public void Start()
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine("Enter 1 to login");
        Console.WriteLine("Enter 2 to create an account");
        Console.WriteLine("Enter 3 to see the menu card");
        Console.WriteLine("Enter 4 to exit the program");

        string input = Console.ReadLine() ?? "";
        if (input == "1")
        {
            UserLogin.Login();
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
