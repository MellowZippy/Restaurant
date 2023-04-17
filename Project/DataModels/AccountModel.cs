using System.Text.Json.Serialization;


public class AccountModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("Admin")]
    public bool Admin { get; set; }

    [JsonPropertyName("Waiter")]
    public bool Waiter { get; set; }

    [JsonPropertyName("Costumer")]
    public bool Costumer { get; set; }

    public AccountModel(int id, string emailAddress, string password, string fullName, bool Admin, bool Waiter, bool Costumer)
    {
        Id = id;
        EmailAddress = emailAddress;
        Password = password;
        FullName = fullName;
        Admin = false;
        Waiter = false;
        Costumer = true;
    }

//it worked
//test again





}




