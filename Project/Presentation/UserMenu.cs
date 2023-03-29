static class UserMenu
{
    public static void LoginMenu(AccountModel account)
    {
        Console.Clear();
        if (Menu.message != "") Console.WriteLine(Menu.message); Menu.message = "";
        Console.WriteLine("Enter 1 to make a reservation");
        Console.WriteLine("Enter 2 to see your reservations");
        string input = Console.ReadLine() ?? "";
        if (input == "1")
        {
            ReservationMenu.MakeReservation(account);
        }
        else if (input == "2")
        {
            Menu.message = "This feature is not yet implemented.\n";
            LoginMenu(account);
        }
        else
        {
            LoginMenu(account);
        }
    }

    public static void SeeReservations()
    {

    }
}
