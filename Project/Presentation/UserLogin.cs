using Newtonsoft.Json;
static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    static private string filePath = "DataSources/accounts.json";

    public class AccountsLogic
    {
        private string filePath = "DataSources/accounts.json";

        public AccountModel CheckLogin(string email, string password)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<AccountModel> accounts = JsonConvert.DeserializeObject<List<AccountModel>>(json);

                // Find an account with a matching email and password
                AccountModel account = accounts.Find(acc => acc.EmailAddress == email && acc.Password == password);

                return account;
            }
            else
            {
                return null;
            }
        }
    }

    public static void Start()
    {
        Console.Clear();
        // Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Welcome to the login page");
        Console.WriteLine();
        Console.ResetColor();
        Login();
    }


    private static void Login()
    {
        // Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Please enter your email address");
        string? email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine();
        Console.ResetColor();
        AccountModel acc = accountsLogic.CheckLogin(email!, password!);
        if (acc != null)
        {
            Menu.message = $"Welcome back {acc.FullName}\nYou are logged in.\n";
            //Write some code to go back to the menu
            UserMenu.LoginMenu(acc);
        }
        else
        {
            Menu.message = "Invalid email or password";
        }
    }

    public static void CreateAccount()
    {
        Console.Clear();
        Console.WriteLine("Please enter your email address");
        string? email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine();
        Console.WriteLine("Please enter your full name");
        string? fullName = Console.ReadLine();

        List<AccountModel> accounts = GetAccounts();
        int nextId = accounts.Count + 1;
        AccountModel acc = new AccountModel(nextId, email!, password!, fullName!);
        accounts.Add(acc);
        SaveAccounts(accounts);

        Menu.message = "Account created successfully\nYou are logged in.\n";
        UserMenu.LoginMenu(acc);
    }

    private static List<AccountModel> GetAccounts()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<AccountModel>>(json);
        }
        else
        {
            return new List<AccountModel>();
        }
    }

    private static void SaveAccounts(List<AccountModel> accounts)
    {
        string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}
