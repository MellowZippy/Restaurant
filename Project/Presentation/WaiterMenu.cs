public class WaiterMenu
{
    static public void WaiterUI()
    {
        Console.Clear();
        Menu.Print();
        Menu.Header("Waiter UI:");
        Console.WriteLine("Enter 1 to see the menu card");
        Console.WriteLine("Enter 2 to manage the customer's presence");
        Console.WriteLine("Enter 3 to manage the customer's order");
        Console.WriteLine("Enter 4 to calculate the receipt");
        Console.WriteLine("Enter 5 to see the information of the reservations");
        Console.WriteLine("Enter 6 to search a reservation's information");
        Console.WriteLine("Enter 'back' to go to the home screen");
        string input = Console.ReadLine() ?? "";
        Console.Clear();
        switch (input.ToUpper())
        {
            case "1": MenuCard.ShowMenuCard(); break;
            case "2": WaiterCommands.TodaysReservations(); Menu.HandleLogin(); break;
            case "3": Menu.message = "! not yet implemented feature !"; Menu.HandleLogin(); break;
            case "4": Menu.message = "! not yet implemented feature !"; Menu.HandleLogin(); break;
            case "5": SearchLogic.OrderByStart("Reservations"); break;
            case "6": SearchLogic.SearchItemStart("Reservations"); break;
            case "BACK": AccountsLogic.SetCurrentAccount(null!); Menu.Start(); break;
            default: WaiterMenu.WaiterUI(); break;
        }
    }
}