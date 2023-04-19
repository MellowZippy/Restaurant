public static class Menu
{
    public static string message = "";

    public static void Print()
    {
        if (message != "") Console.WriteLine(message + "\n"); message = "";
    }

    public static void Header(string message)
    {
        Console.WriteLine(new string('-', 20));
        Console.WriteLine(message);
        Console.WriteLine(new string('-', 20));
    }

    public static void PressEnter()
    {
        Console.WriteLine("Press 'Enter' to continue");
        Console.ReadLine();
    }

    public static void HandleLogin()
    {
        if (AccountsLogic.CurrentAccount == null) throw new NullReferenceException("Error. Current account is null.");
        else if (AccountsLogic.CurrentAccount.IsCustomer == true) UserMenu.UserUI();
        else if (AccountsLogic.CurrentAccount.IsAdmin == true) AdminMenu.AdminUI();
        else if (AccountsLogic.CurrentAccount.IsWaiter == true) WaiterMenu.WaiterUI();
        else
        {
            throw new DataMisalignedException("Account proporties are wrong. See in accounts.json if every account has the right booleans.");
        }
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