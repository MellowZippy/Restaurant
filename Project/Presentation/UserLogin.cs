using Newtonsoft.Json;
static class UserLogin
{
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
        AccountModel acc = AccountsLogic.CheckLogin(email!, password!);
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
        Menu.Print();
        AccountModel acc = AccountsLogic.CurrentAccount!;
        Console.WriteLine("Please enter your CURRENT password");
        string password = Console.ReadLine() ?? "";
        if (acc.Password != password) { Menu.message = "Wrong password. Try again."; ChangePassword(); }
        else
        {
            Console.WriteLine("Please enter your NEW password:");
            string newPassword = Console.ReadLine() ?? "";
            acc.Password = newPassword!;
            string json = JsonConvert.SerializeObject(acc, Formatting.Indented);
            List<AccountModel> accounts = AccountsAccess.LoadAll();
            int index = accounts.FindIndex(a => a.Id == acc.Id);
            accounts[index] = acc;
            AccountsAccess.WriteAll(accounts);
            Menu.message = $"\nYour password is succesfully changed to: {acc.Password}";
            Menu.HandleLogin();
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