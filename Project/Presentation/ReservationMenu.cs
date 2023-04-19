public static class ReservationMenu
{
    public static Random random = new Random();
    public static DateTime userDate;

    public static void MakeReservation()
    {
        ShowCalender();
        string time = TimeTable(16, 22);
        int quantityPeople = HowManyPeople();
        string reservationCode = ConfirmReservation();
        AccountModel account = AccountsLogic.CurrentAccount!;
        ReservationModel newReservation = ReservationsLogic.AddReservation(userDate, time, quantityPeople, account.FullName, account.Id, reservationCode);
        Console.WriteLine($"\n{newReservation.ToString()}\n");
        Console.ReadLine();
        UserMenu.LoginMenu();
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
        var headingSpaces = new string(' ', 13 - dateMonth.ToString("MMMM").Length);
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("Calendar");
        Console.WriteLine();
        Console.WriteLine($"{dateMonth.ToString("MMMM")}{headingSpaces}{dateMonth.ToString("MM")}/{dateMonth.Year}");
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
        Console.WriteLine(new string('-', 20));
        Console.WriteLine("Press 'Enter' to start choosing.");
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
        // returns the day, month and year in a datetime object
        else
        {
            bool isCorrect = false;
            while (isCorrect == false)
            {
                int inputDay = CheckIfInputIsInt("Day");
                int inputMonth = CheckIfInputIsInt("Month");
                int inputYear = CheckIfInputIsInt("Year");
                string dateInString = $"{inputDay.ToString().PadLeft(2, '0')}/{inputMonth.ToString().PadLeft(2, '0')}/{inputYear}";
                DateTime temp;
                if (DateTime.TryParse(dateInString, out temp))
                {
                    try
                    {
                        userDate = new DateTime(inputYear, inputMonth, inputDay);
                        if (DateTime.Compare(DateTime.Now, userDate) < 0) isCorrect = true;
                        else Console.WriteLine("\nInvalid input, this date has already passed. Try again.\n");
                    }
                    catch
                    {
                        Console.WriteLine("\nInvalid input, date doesnt exist. Try again.\n");
                    }
                }
                else Console.WriteLine("\nInvalid input, date doesn't exist. Try again.\n");
            }
        }
    }

    public static int CheckIfInputIsInt()
    {
        int i = 0;
        while (true)
        {
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out i)) return int.Parse(input);
            else Console.WriteLine("Invalid input, your input has to be a number.");
        }
    }

    public static int CheckIfInputIsInt(string what)
    {
        int i = 0;
        while (true)
        {
            Console.Write($"{what}: ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out i)) return int.Parse(input);
            else Console.WriteLine("Invalid input, it has to be a number.");
        }
    }

    public static string TimeTable(int open, int close)
    {
        Console.Clear();
        Console.WriteLine("Choose a time for your reservation:");
        Console.WriteLine();
        int restaurantOpenTime = close - open; // from 16:00 to 22:00 is the restaurant open for testing purposes
        List<string> availableTimes = new List<string>();
        for (int i = 1; i < restaurantOpenTime + 1; i++)
        {
            string aTime = $"{open}:00 - {open + 1}:00";
            open += 1;
            availableTimes.Add(aTime);
        }
        for (int i = 0; i < restaurantOpenTime; i++)
        {
            Console.WriteLine($"{i + 1}) " + availableTimes[i]);
        }
        Console.WriteLine();
        int answer = 0;
        bool isCorrect = false;
        while (isCorrect == false)
        {
            answer = CheckIfInputIsInt();
            if (answer >= 1 && answer <= availableTimes.Count) isCorrect = true;
            else Console.WriteLine("Invalid input: has to be a number from 1 to {0}", availableTimes.Count);
        }
        for (int i = 0; i < availableTimes.Count; i++)
        {
            if (answer == i + 1) return availableTimes[i];
        }
        return "a time";
    }

    public static int HowManyPeople()
    {
        Console.Clear();
        Console.Write("People: ");
        int quantityPeople = CheckIfInputIsInt();
        return quantityPeople;
    }

    public static string ConfirmReservation()
    {
        Console.WriteLine("Confirm your reservation by pressing 'Enter' or enter 'cancel' to cancel");
        string action = Console.ReadLine() ?? "";
        if (action == "cancel")
        {
            Menu.message = "Your reservation has been canceled";
            return "";
        }
        else
        {
            Menu.message = "Your reservation has been made.";
            string reservationCode = CreateReservationCode();
            Console.WriteLine($"Your reservation code is: {reservationCode}\n");
            Menu.PressEnter();
            return reservationCode;
        }
    }

    public static string CreateReservationCode()
    {
        int lengthOfReservationCode = 5;
        char[] keys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890".ToCharArray();

        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        List<string> allResCodes = new List<string>();
        foreach (ReservationModel reservation in reservations)
        {
            allResCodes.Add(reservation.ReservationCode);
        }
        while (true)
        {
            string resCode = "";
            for (int i = 0; i < lengthOfReservationCode; i++)
            {
                resCode += keys[random.Next(0, keys.Length - 1)];
            }
            if (!allResCodes.Contains(resCode)) return resCode;
        }
    }

    public static void SeeReservations()
    {
        Console.Clear();
        Console.WriteLine("Your reservations:");
        List<ReservationModel> UserReservationsList = ReservationsLogic.FindAccountReservation();
        if (UserReservationsList.Count != 0)
        {
            for (int i = 0; i < UserReservationsList.Count; i++)
            {
                Console.WriteLine($"Reservation {i + 1}: {UserReservationsList[i].ToString()}");
            }
        }
        else Console.WriteLine("You have no reservations");
        Console.ReadLine();
        UserMenu.LoginMenu();
    }
}