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
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Welcome to the login page");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Create an account");
        Console.ResetColor();
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Login();
                break;
            case 2:
                CreateAccount();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }


    private static void Login()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Please enter your email address");
        string? email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string? password = Console.ReadLine();
        Console.ResetColor();
        AccountModel acc = accountsLogic.CheckLogin(email!, password!);
        if (acc != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome back " + acc.FullName);
            Console.WriteLine("Your email number is " + acc.EmailAddress);
            Console.ResetColor();
            //Write some code to go back to the menu
            Menu.Start();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid email or password");
            Console.ResetColor();
        }
    }

    private static void CreateAccount()
    {
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

        Console.WriteLine("Account created successfully");
    }

    private static List<AccountModel> GetAccounts()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<AccountModel>>(json)!;
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
