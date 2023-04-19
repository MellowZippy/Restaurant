static class Menu
{
    public static string message = "";

    public static void Print()
    {
        if (message != "") Console.WriteLine(message + "\n"); message = "";
    }

    public static void PressEnter()
    {
        Console.WriteLine("Press 'Enter' to continue");
        Console.ReadLine();
    }
    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    

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
        AdminMenu.AdminUI();

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

    static public void Pause()
    {
        Console.Write("Press enter to continue");
        Console.ReadLine();
    }
}