public class Reservation
{
    public DateTime Date;
    public string Time;
    public int QuantityPeople;
    public string CustomerName;

    public Reservation(DateTime date, string time, int quantityPeople, string customerName)
    {
        Date = date;
        Time = time;
        QuantityPeople = quantityPeople;
        CustomerName = customerName;
    }

    public override string ToString()
    {
        return $"Date: {Date}, Time: {Time}, QuantityPeople: {QuantityPeople}, CustomerName: {CustomerName}";
    }
}
