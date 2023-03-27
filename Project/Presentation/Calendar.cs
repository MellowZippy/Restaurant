public static class UserCalendar
{
    static int month = new int();
    static int[,] calendar = new int[6, 7];
    private static DateTime date;

    public static void Start()
    {
        int UserYear = DateTime.Now.Year;
        int UserMonth = DateTime.Now.Month;
        Calendar(UserYear, UserMonth);
    }

    public static void Calendar(int year, int month)
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
        else
        {
            Calendar(year, month);
        }
    }
}