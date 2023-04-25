using System;

class ForeGround
{
    /*
      public static void Main()
      {
        ForeGroundStartScreen();
      }
    */

    public static void ForeGroundStartScreen()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;  // Kleur lettertype veranderen
        Console.BackgroundColor = ConsoleColor.Black;

        System.Console.WriteLine(" ___________________________________________________________________________________________________________");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|     __    __    __    ________    __          __________    ___________    ______________    ________     |");
        System.Console.WriteLine("|    |  |  |  |  |  |  |   _____|  |  |        |   _______|  |   _____   |  |   __    __   |  |   _____|    |");
        System.Console.WriteLine("|    |  |  |  |  |  |  |  |_____   |  |        |  |          |  |     |  |  |  |  |  |  |  |  |  |_____     |");
        System.Console.WriteLine("|    |  |  |  |  |  |  |   _____|  |  |        |  |          |  |     |  |  |  |  |  |  |  |  |   _____|    |");
        System.Console.WriteLine("|    |  |__|  |__|  |  |  |_____   |  |_____   |  |_______   |  |_____|  |  |  |  |  |  |  |  |  |_____     |");
        System.Console.WriteLine("|    |______________|  |________|  |________|  |__________|  |___________|  |__|  |__|  |__|  |________|    |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                  ----- WHAT DO YOU WANT TO DO? -----                                      |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                         _____________________                                             |");
        System.Console.WriteLine("|                                        | 1. LOG IN USER      |                                            |");
        System.Console.WriteLine("|                                        | 2. CREATE ACCOUNT   |                                            |");
        System.Console.WriteLine("|                                        | 3. SEE MENUCARD     |                                            |");
        System.Console.WriteLine("|                                        | 4. EXIT PROGRAM     |                                            |");
        System.Console.WriteLine("|                                        |                     |                                            |");
        System.Console.WriteLine("|                                        |_____________________|                                            |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|___________________________________________________________________________________________________________|");
        System.Console.WriteLine("");


        int choiceUser = ReservationMenu.CheckIfInputIsInt();

        switch (choiceUser)
        {
            case 1:
                UserLogin.Login();
                break;
            case 2:
                UserLogin.CreateAccount();
                break;
            case 3:
                MenuCard.ShowMenuCard();
                MenuCard.BackToMenu();
                break;
            case 4:
                System.Environment.Exit(0);
                break;
            default:
                ForeGround.ForeGroundStartScreen();
                break;
        }
    }
}
