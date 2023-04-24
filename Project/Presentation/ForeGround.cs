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
        System.Console.WriteLine("|                                        | 2. CHANGE PASSWORD  |                                            |");
        System.Console.WriteLine("|                                        | 3. CREATE ACCOUNT   |                                            |");
        System.Console.WriteLine("|                                        | 4. SEE MENUCARD     |                                            |");
        System.Console.WriteLine("|                                        | 5. EXIT PROGRAM     |                                            |");
        System.Console.WriteLine("|                                        |_____________________|                                            |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|___________________________________________________________________________________________________________|");
        System.Console.WriteLine("");

<<<<<<< HEAD
        Console.ForegroundColor = ConsoleColor.White;  //Terug naar standaard (achter)grondkleur
        Console.BackgroundColor = ConsoleColor.Black;

        int choiceUser = Convert.ToInt32(Console.ReadLine());
=======
        int choiceUser = ReservationMenu.CheckIfInputIsInt();
>>>>>>> d6b9ac732541c044a88d87306a328fa7d32ae060

        switch (choiceUser)
        {
          case 1:
            UserLogin.Login();
            break;

          case 2:
            UserLogin.ChangePassword();
            break;

          case 3:
            UserLogin.CreateAccount();
            break;
          
          case 4:
            MenuCard.ShowMenuCard();
            break;
          
          case 5:
            System.Environment.Exit(0);
            break;

          default:
            ForeGround.ForeGroundStartScreen();
            break;
        }
    }
}
