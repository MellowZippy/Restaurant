using System.Text.Json;

static class ReservationsAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservations.json"));


    public static List<ReservationModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<ReservationModel>>(json)!;
    }


    public static void WriteAll(List<ReservationModel> reservations)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(reservations.OrderBy(x => x.Id).ToList(), options);
        File.WriteAllText(path, json);
    }

    public static List<ReservationModel> AscIDMyJson()
    {
        string json = File.ReadAllText(ReservationsAccess.path);
        var listOb = JsonSerializer.Deserialize<List<ReservationModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.Id).ToList();
        return descListOb;
    }

    public static List<ReservationModel> AscNameMyJson()
    {
        string json = File.ReadAllText(ReservationsAccess.path);
        var listOb = JsonSerializer.Deserialize<List<ReservationModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.FullName).ToList();
        return descListOb;
    }

    public static List<ReservationModel> AscDateMyJson()
    {
        string json = File.ReadAllText(ReservationsAccess.path);
        var listOb = JsonSerializer.Deserialize<List<ReservationModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.Date).ToList();
        return descListOb;
    }

    public static List<ReservationModel> AscPeopleMyJson()
    {
        string json = File.ReadAllText(ReservationsAccess.path);
        var listOb = JsonSerializer.Deserialize<List<ReservationModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.QuantityPeople).ToList();
        return descListOb;
    }
}