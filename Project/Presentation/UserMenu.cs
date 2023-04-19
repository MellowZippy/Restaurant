static class UserMenu
{
    public static void UserUI()
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("User UI:");
        Console.WriteLine(new string('-', 20));
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
            case "BACK": AccountsLogic.SetCurrentAccount(null!); Menu.Start(); break;
            default: UserMenu.UserUI(); break;
        }
        Console.WriteLine("Invalid input");
        AdminMenu.AdminUI();
    }
}