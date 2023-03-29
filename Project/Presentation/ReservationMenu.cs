public static class ReservationMenu
{
    public static DateTime userDate;

    public static void MakeReservation(AccountModel account)
    {

        ShowCalender();
        string time = TimeTable();
        int quantityPeople = HowManyPeople();
        Reservation newReservation = new Reservation(userDate, time, quantityPeople, account.FullName);
        Console.WriteLine($"\n{newReservation.ToString()}\n");
        Console.ReadLine();
        UserMenu.LoginMenu(account);
    }

    public static void ShowCalender()
    {
        int UserYear = DateTime.Now.Year;
        int UserMonth = DateTime.Now.Month;
        Calendar(UserYear, UserMonth);
    }

    private static void Calendar(int year, int month)
    {
        Console.Clear();
        var dateMonth = new DateTime(year, month, 1);
        var headingSpaces = new string(' ', 16 - dateMonth.ToString("MMMM").Length);
        Console.WriteLine($"{dateMonth.ToString("MMMM")}{headingSpaces}{dateMonth.Year}");
        Console.WriteLine();
        Console.WriteLine("Mo Tu We Th Fr Sa Su ");
        var padLeftDays = ((int)dateMonth.DayOfWeek - 1 < 0) ? 6 : (int)dateMonth.DayOfWeek - 1; // instead of DayOfWeek starting at sunday, its now starts at monday
        var currentDay = dateMonth;
        var iterations = DateTime.DaysInMonth(dateMonth.Year, dateMonth.Month) + padLeftDays;
        for (int j = 0; j < iterations; j++)
        {
            if (j < padLeftDays)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write($"{currentDay.Day.ToString().PadLeft(2, ' ')} ");

                if ((j + 1) % 7 == 0)
                {
                    Console.WriteLine();
                }
                currentDay = currentDay.AddDays(1);
            }
        }
        Console.WriteLine("\n");
        Console.WriteLine("Use LEFT ARROW and RIGHT ARROW to navigate months!");
        var action = Console.ReadKey().Key;
        if (action == ConsoleKey.LeftArrow)
        {
            if (month == 1) Calendar(year - 1, 12);
            else Calendar(year, month - 1);
        }
        else if (action == ConsoleKey.RightArrow)
        {
            if (month == 12) Calendar(year + 1, 1);
            else Calendar(year, month + 1);
        }
        // return the day, month and year in a datetime object
        else userDate = dateMonth;
    }

    public static string TimeTable()
    {
        Console.Clear();
        Console.WriteLine("Choose a time for your reservation:");
        Console.WriteLine();
        int opening = 16;
        int closing = 22;
        int restaurantOpenTime = closing - opening; // from 16:00 to 22:00 is the restaurant open for testing purposes
        for (int i = 1; i < restaurantOpenTime + 1; i++)
        {
            Console.WriteLine($"{i}) {opening}:00 - {opening + 1}:00");
            opening += 1;
        }
        Console.WriteLine();
        Console.ReadLine();
        return "a time";
    }

    public static int HowManyPeople()
    {
        Console.Clear();
        Console.Write("People: ");
        int quantityPeople = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Confirm your reservation by clicking here");
        Menu.message = "Your reservation has been made.\n";
        Console.ReadLine();
        Console.WriteLine("Your reservation code is: 12345");
        Console.ReadLine();
        return quantityPeople;
    }
}
