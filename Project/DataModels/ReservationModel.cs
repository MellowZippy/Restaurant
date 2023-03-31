using System.Text.Json.Serialization;


public class ReservationModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("quantityPeople")]
    public int QuantityPeople { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }



    public ReservationModel(int id, DateTime date, string time, int quantityPeople, string fullName, int accountId)
    {
        Id = id;
        Date = date;
        Time = time;
        QuantityPeople = quantityPeople;
        FullName = fullName;
        AccountId = accountId;
    }

    public override string ToString()
    {
        return $"Date: {Date}, Time: {Time}, QuantityPeople: {QuantityPeople}, CustomerName: {FullName}, AccountId: {AccountId}";
    }
}



