public static class AdminMenu
{
    public static void AdminUI()
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine("Admin commands:");
        Console.WriteLine("Enter 'A' to search an account");
        Console.WriteLine("Enter 'B' to see the accounts ordered");
        Console.WriteLine("Enter 'C' to search a dish");
        Console.WriteLine("Enter 'D' to see the food ordered");
        Console.WriteLine("Enter 'E' to search a reservation");
        Console.WriteLine("Enter 'F' to see the reservations ordered");
        Console.WriteLine("Enter 'back' to go to the home screen");

        string input = Console.ReadLine() ?? "";
        Console.Clear();

        switch (input.ToUpper())
        {
            case "A": SearchLogic.SearchItemStart("Accounts"); break;
            case "B": SearchLogic.OrderByStart("Accounts"); break;
            case "C": SearchLogic.SearchItemStart("Food"); break;
            case "D": SearchLogic.OrderByStart("Food"); break;
            case "E": SearchLogic.SearchItemStart("Reservations"); break;
            case "F": SearchLogic.OrderByStart("Reservations"); break;
            case "BACK": AccountsLogic.SetCurrentAccount(null!); Menu.Start(); break;
            default: AdminMenu.AdminUI(); break;
        }
    }

    static public void ShowAdminCommands()
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
            AdminUI();
        }
    }
}