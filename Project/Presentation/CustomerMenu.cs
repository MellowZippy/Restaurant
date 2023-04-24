static class CustomerMenu
{
    public static void CustomerUI()
    {
        Console.Clear();
        Menu.Print();
        Menu.Header("Customer UI:");
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
            case "2": ReservationMenu.SeeReservations(); Menu.PressEnter(); Menu.HandleLogin(); break;
            case "3": ReservationMenu.ChangeReservation(); break; // WORKS, BUT NOT YET DONE
            case "4": ReservationMenu.CancelReservation(); break; // WORKS, BUT NOT YET DONE
            case "BACK": AccountsLogic.SetCurrentAccount(null!); Menu.Start(); break;
            default: CustomerMenu.CustomerUI(); break;
        }
        Console.WriteLine("Invalid input");
        AdminMenu.AdminUI();
    }
}