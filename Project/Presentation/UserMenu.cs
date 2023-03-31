static class UserMenu
{
    public static void LoginMenu(AccountModel account)
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine("Enter 1 to make a reservation");
        Console.WriteLine("Enter 2 to see your reservations");
        string input = Console.ReadLine() ?? "";
        if (input == "1")
        {
            ReservationMenu.MakeReservation(account);
        }
        else if (input == "2")
        {
            ReservationMenu.SeeReservations(account);
        }
        else
        {
            LoginMenu(account);
        }
    }
}
