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

    public static void HandleLogin()
    {
        if (AccountsLogic.CurrentAccount.Customer == true) UserUI();
        else if (AccountsLogic.CurrentAccount.Admin == true) AdminUI();
        else if (AccountsLogic.CurrentAccount.Waiter == true) WaiterUI();
        else
        {
            throw new DataMisalignedException("Account proporties are wrong.");
        }
    }
    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    

    static public void UserUI()
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine("Enter 1 to make a reservation");
        Console.WriteLine("Enter 2 to see your reservations");
        Console.WriteLine("Enter 3 to change your reservation");
        Console.WriteLine("Enter 4 to cancel your reservation");
        Console.WriteLine("Enter 'back' to go to the home screen");
        string input = Console.ReadLine() ?? "";
        Console.Clear();
        switch (input.ToUpper())
        {
            case "1": ReservationMenu.MakeReservation(); break;
            case "2": ReservationMenu.SeeReservations(); break;
            case "3": Menu.message = "! not yet implemented feature !"; Menu.HandleLogin(); break;
            case "4": Menu.message = "! not yet implemented feature !"; Menu.HandleLogin(); break;
            case "BACK": Menu.Start(); break;
            default: Menu.UserUI(); break;
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