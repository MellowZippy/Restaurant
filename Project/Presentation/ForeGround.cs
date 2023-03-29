using System;

class ForeGround
{
    static void Main()
    {
      ForeGroundStartScreen();
    }

    static void ForeGroundStartScreen()
    {
        Console.ForegroundColor = ConsoleColor.Blue;  // Kleur lettertype veranderen
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
        System.Console.WriteLine("|                                  ----- WHAT DO YOU WANT TO DO? -----                                      |");
        System.Console.WriteLine("|                                         _____________________                                             |");
        System.Console.WriteLine("|                                        |   1. LOG IN USER    |                                            |");
        System.Console.WriteLine("|                                        |   2. CREATE ACCOUNT |                                            |");
        System.Console.WriteLine("|                                        |   3. SEE MENUCARD   |                                            |");
        System.Console.WriteLine("|                                        |   4. EXIT PROGRAM   |                                            |");
        System.Console.WriteLine("|                                        |_____________________|                                            |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|                                                                                                           |");
        System.Console.WriteLine("|___________________________________________________________________________________________________________|");
        System.Console.WriteLine("");

        int choiceUser = Convert.ToInt32(Console.ReadLine());

        switch (choiceUser)
        {
          case 1:
            UserLogin.Start();
            break;

          case 2:
            UserLogIn.CreateAccount();
            break;
          
          case 3:
            MenuCard.ShowMenuCard();
            break;
          
          case 4:
            System.Environment.Exit(0);
            break;
        }


        Console.ForegroundColor = ConsoleColor.White;  //Terug naar standaard (achter)grondkleur
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
