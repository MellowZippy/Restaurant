static class MenuCard
{
    static private FoodLogic _foodLogic = new FoodLogic();   

    public static void ShowMenuCard()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"EL MENU");
        Console.ForegroundColor = ConsoleColor.White;

        List<FoodModel> foodList = FoodAccess.LoadAll();
        foreach(FoodModel foodItem in foodList)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {foodItem.Id} | {foodItem.Name} | ${foodItem.Price} | {foodItem.Description} |");
                   
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

}