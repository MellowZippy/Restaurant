static class MenuCard
{
    static private FoodLogic _foodLogic = new FoodLogic();

    public static void ShowMenuCard()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("EL MENU".PadLeft(290, ' '));
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
 
        List<FoodModel> foodList = FoodAccess.LoadAll();
        foreach (FoodModel foodItem in foodList)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {foodItem.Id.ToString().PadLeft(2, '0')} | {foodItem.Name.PadLeft(20, '-')} | ${foodItem.Price.ToString().PadLeft(10, '-')} | {foodItem.Description.PadLeft(100, '-')} |");

        }
        Console.ForegroundColor = ConsoleColor.White;
        Menu.Pause();
    }
}

