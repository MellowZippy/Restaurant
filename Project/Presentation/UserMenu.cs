static class UserMenu
{
    public static void LoginMenu()
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine("Enter 1 to make a reservation");
        Console.WriteLine("Enter 2 to see your reservations");
        Console.WriteLine("Enter 'back' to go to the home screen");
        Console.WriteLine();
        Console.WriteLine("Admin commands:");
        Console.WriteLine("Enter 'AccountsSearch' to search an account");
        Console.WriteLine("Enter 'AccountsOrderBy' to see the accounts ordered");
        Console.WriteLine("Enter 'FoodSearch' to search a dish");
        Console.WriteLine("Enter 'FoodOrderBy' to see the food ordered");
        Console.WriteLine("Enter 'ReservationsSearch' to search a reservation");
        Console.WriteLine("Enter 'ReservationsOrderBy' to see the reservations ordered");
        string input = Console.ReadLine() ?? "";
        Console.Clear();
        switch (input)
        {
            case "1": ReservationMenu.MakeReservation(); break;
            case "2": ReservationMenu.SeeReservations(); break;
            case "back": Menu.Start(); break;
            case "AccountsSearch": Logic.SearchItemStart("Accounts"); break;
            case "AccountsOrderBy": Logic.OrderByStart("Accounts"); break;
            case "FoodSearch": Logic.SearchItemStart("Food"); break;
            case "FoodOrderBy": Logic.OrderByStart("Food"); break;
            case "ReservationsSearch": Logic.SearchItemStart("Reservations"); break;
            case "ReservationsOrderBy": Logic.OrderByStart("Reservations"); break;
            default: LoginMenu(); break;
        }
    }
}