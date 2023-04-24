using Newtonsoft.Json;
static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    // static private string filePath = "DataSources/accounts.json";

    public static void Login()
    {
        // doc: this is where all the users can login, if account is found, they are send to their login menu screen, else they are send back to the home screen with an error message
        Console.Clear();
        Console.WriteLine("Welcome to the login page\n");
        Console.WriteLine("Please enter your email address");
        string? email = (Console.ReadLine() ?? "").TrimEnd();
        Console.WriteLine("Please enter your password");
        string? password = (Console.ReadLine() ?? "").TrimEnd();
        Console.ResetColor();
        AccountModel acc = accountsLogic.CheckLogin(email!, password!);
        if (acc != null)
        {
            Menu.HandleLogin();
        }
        else
        {
            Menu.message = "Invalid email or password";
            Menu.Start();
        }
    }

        public static void ChangePassword()
    {
        Console.Clear();
        System.Console.WriteLine("To change your password you have to login first.");
        System.Console.WriteLine("Please enter your email adress:");
        string? email = Console.ReadLine();
        //System.Console.WriteLine("\n");
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine();
        System.Console.WriteLine("\n");
        AccountModel acc = accountsLogic.CheckLogin(email!, password!);
        
        if (acc != null)
        {
            Console.Clear();
            System.Console.WriteLine("You are succesfully logged in.\nPlease enter your NEW password:");
            string? newPassword = Console.ReadLine();
            acc.Password = newPassword!;
            string json = JsonConvert.SerializeObject(acc, Formatting.Indented);
            List<AccountModel> accounts = AccountsAccess.LoadAll();
            int index = accounts.FindIndex(a => a.Id == acc.Id);
            accounts[index] = acc;
            AccountsAccess.WriteAll(accounts);

            System.Console.WriteLine($"\nYour password is succesfully changed to: {acc.Password}\nLogin again with your new password.\n");
            System.Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            UserLogin.Login();
        }

        else
        {
            System.Console.WriteLine("The email and/or password dont match\nPlease try again...");
            System.Console.WriteLine("Press enter to go back");
            Console.ReadLine();
            UserLogin.ChangePassword();
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
            AccountsLogic.AddAccount(email!, password!, fullName!, false, false, true);
            Menu.message = "Account created successfully\nYou are logged in.\n";
            Menu.HandleLogin();
        }
        else
        {
            Menu.message = "Error, account with same email exists.";
            Menu.Start();
        }
    }
}