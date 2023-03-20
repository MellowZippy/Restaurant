using System.Text.Json.Serialization;


class FoodModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    public FoodModel(int id, string name, double price, string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
    }
}