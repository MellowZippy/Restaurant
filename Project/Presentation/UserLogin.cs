using Newtonsoft.Json;
static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    static private string filePath = "DataSources/accounts.json";

    public static void Login()
    {
        // doc: this is where all the users can login, if account is found, they are send to their login menu screen, else they are send back to the home screen with an error message
        Console.Clear();
        Console.WriteLine("Welcome to the login page\n");
        Console.WriteLine("Please enter your email address");
        string? email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine();
        Console.ResetColor();
        AccountModel acc = accountsLogic.CheckLogin(email!, password!);
        if (acc != null)
        {
            Menu.message = $"Welcome back {acc.FullName}\nYou are logged in.\n";
            UserMenu.LoginMenu();
        }
        else
        {
            Menu.message = "Invalid email or password";
            Menu.Start();
        }
    }

    public static void CreateAccount()
    {
        Console.Clear();
        Menu.Print();
        Console.WriteLine("Create account:\n");
        Console.WriteLine("Please enter your email address");
        string email = Console.ReadLine() ?? "";
        Console.WriteLine("Please enter your password");
        string password = Console.ReadLine() ?? "";
        Console.WriteLine("Please enter your full name");
        string fullName = Console.ReadLine() ?? "";
        if (email == "" || password == "" || fullName == "")
        {
            Menu.message = "Error, You didn't input any text";
            CreateAccount();
        }
        if (AccountsLogic.CheckIfEmailExists(email) == false)
        {
            AccountsLogic.AddAccount(email!, password!, fullName!, false, false);
            Menu.message = "Account created successfully\nYou are logged in.\n";
            UserMenu.LoginMenu();
        }
        else
        {
            Menu.message = "Error, account with same email exists.";
            Menu.Start();
        }
    }
}