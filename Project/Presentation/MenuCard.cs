static class MenuCard
{
    static private FoodLogic _foodLogic = new FoodLogic();   

    public static void Main()
    {
        List<FoodModel> foodList = FoodAccess.LoadAll();
        foreach(foodModel foodItem in foodList)
        {
            Console.WriteLine(foodItem.Name);
        }
    }
}