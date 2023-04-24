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
}