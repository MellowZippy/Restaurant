static class UserMenu
{
    public static void LoginMenu()
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine("Enter 1 to make a reservation");
        Console.WriteLine("Enter 2 to see your reservations");
        Console.WriteLine("Enter 3 to change your reservation");
        Console.WriteLine("Enter 4 to cancel your reservation");
        Console.WriteLine("Enter 'back' to go to the home screen");
        Console.WriteLine();
        Console.WriteLine("Admin commands:");
        Console.WriteLine("Enter 'A' to search an account");
        Console.WriteLine("Enter 'B' to see the accounts ordered");
        Console.WriteLine("Enter 'C' to search a dish");
        Console.WriteLine("Enter 'D' to see the food ordered");
        Console.WriteLine("Enter 'E' to search a reservation");
        Console.WriteLine("Enter 'F' to see the reservations ordered");
        string input = Console.ReadLine() ?? "";
        Console.Clear();
        switch (input.ToUpper())
        {
            case "1": ReservationMenu.MakeReservation(); break;
            case "2": ReservationMenu.SeeReservations(); break;
            case "3": Menu.message = "! not yet implemented feature !"; UserMenu.LoginMenu(); break;
            case "4": Menu.message = "! not yet implemented feature !"; UserMenu.LoginMenu(); break;
            case "back": Menu.Start(); break;
            case "A": Logic.SearchItemStart("Accounts"); break;
            case "B": Logic.OrderByStart("Accounts"); break;
            case "C": Logic.SearchItemStart("Food"); break;
            case "D": Logic.OrderByStart("Food"); break;
            case "E": Logic.SearchItemStart("Reservations"); break;
            case "F": Logic.OrderByStart("Reservations"); break;
            default: LoginMenu(); break;
        }
    }
}