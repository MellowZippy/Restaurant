public static class WaiterCommands
{
    public static void TodaysReservations()
    {
        List<ReservationModel> reservationsToday = ReservationsAccess.TodaysReservations();
        Menu.Header("Today's reservations:");
        for (int i = 0; i < reservationsToday.Count; i++)
        {
            ReservationModel res = reservationsToday[i];
            Console.WriteLine($"Reservation {i + 1}: Customer's name: {res.FullName}, Timeslot: {res.Time}, Quantity People: {res.QuantityPeople}, Code: {res.ReservationCode}");
        }
        Console.WriteLine();
        Menu.PressEnter();
    }

    public static ReservationModel WaiterChooseReservation()
    {
        List<ReservationModel> reservationsToday = ReservationsAccess.TodaysReservations();
        Console.WriteLine("Choose a reservation to connect to a table");
        int action = ReservationMenu.CheckIfInputIsInt();
        for (int i = 0; i < reservationsToday.Count; i++)
        {
            if (action == i + 1)
            {
                return reservationsToday[i];
            }
        }
        return null!;
    }

    public static void AddReservationToTable(ReservationModel reservation)
    {

    }
}