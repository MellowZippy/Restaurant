using System.Text.Json;

static class AccountsAccess
{
    public static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/accounts.json"));

    public static List<AccountModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<AccountModel>>(json)!;
    }


    public static void WriteAll(List<AccountModel> accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(path, json);
    }

    public static List<AccountModel> AscIDMyJson()
    {
        string json = File.ReadAllText(AccountsAccess.path);
        var listOb = JsonSerializer.Deserialize<List<AccountModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.Id).ToList();
        return descListOb;
    }

    public static List<AccountModel> AscNameMyJson()
    {
        string json = File.ReadAllText(AccountsAccess.path);
        var listOb = JsonSerializer.Deserialize<List<AccountModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.FullName).ToList();
        return descListOb;
    }
}