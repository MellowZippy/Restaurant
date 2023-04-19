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
        string input = Console.ReadLine() ?? "";
        Console.Clear();
        switch (input.ToUpper())
        {
            case "1": ReservationMenu.MakeReservation(); break;
            case "2": ReservationMenu.SeeReservations(); break;
            case "3": Menu.message = "! not yet implemented feature !"; UserMenu.LoginMenu(); break;
            case "4": Menu.message = "! not yet implemented feature !"; UserMenu.LoginMenu(); break;
            case "BACK": Menu.Start(); break;
            default: LoginMenu(); break;
        }
    }
    
}