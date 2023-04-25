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
        Console.WriteLine("Enter 5 to change your password");
        Console.WriteLine("Enter 6 to see the menu");
        Console.WriteLine("Enter 'back' to go to the home screen");
        
        string input = Console.ReadLine() ?? "";
        Console.Clear();
        switch (input.ToUpper())
        {
            case "1": ReservationMenu.MakeReservation(); break;
            case "2": ReservationMenu.SeeReservations(); Menu.PressEnter(); Menu.HandleLogin(); break;
            case "3": ReservationMenu.ChangeReservation(); break; // WORKS, BUT NOT YET DONE
            case "4": ReservationMenu.CancelReservation(); break; // WORKS, BUT NOT YET DONE
            case "5": UserLogin.ChangePassword(); break;
            case "6": MenuCard.ShowMenuCard(); break;
            case "BACK": AccountsLogic.SetCurrentAccount(null!); ForeGround.ForeGroundStartScreen(); break;
            default: CustomerMenu.CustomerUI(); break;
        }
        Console.WriteLine("Invalid input");
        CustomerMenu.CustomerUI();
    }
}