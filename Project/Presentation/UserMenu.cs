static class UserMenu
{
    public static void LoginMenu()
    {
        Console.Clear();
        if (Menu.message != "") Console.WriteLine(Menu.message); Menu.message = "";
        Console.WriteLine("Enter 1 to make a reservation");
        Console.WriteLine("Enter 2 to see your reservations");
        string input = Console.ReadLine() ?? "";
        if (input == "1")
        {
            ReservationMenu.Start();
        }
        else if (input == "2")
        {
            Menu.message = "This feature is not yet implemented.\n";
            LoginMenu();
        }
        else
        {
            LoginMenu();
        }
    }

    public static void MakeReservation()
    {

    }

    public static void SeeReservations()
    {

    }
}
