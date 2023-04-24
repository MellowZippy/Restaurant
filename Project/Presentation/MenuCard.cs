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
        Menu.PressEnter();
        if (AccountsLogic.CurrentAccount != null) Menu.HandleLogin();

    }

    public static void DeleteFromMenuCard()
    {
        Console.WriteLine("What item do you want to remove?");
        Console.Write("ID: ");
        int choiceUser = ReservationMenu.CheckIfInputIsInt();

        FoodLogic foodLogic = new FoodLogic();

        FoodModel ChangingFoodItem = foodLogic.GetById(choiceUser);
        foodLogic.DeleteById(choiceUser);
    }

    public static void DeleteAllItemsFromMenuCard()
    {
        FoodLogic foodLogic = new FoodLogic();
        for (int i = 0; i <= foodLogic.foodCount; i++)
        {
            foodLogic.DeleteById(i);
        }
    }

    public static void ShowMenuOptions()
    {
        Console.WriteLine("What do you want to do with the menu?");
        Console.WriteLine("[D] Delete an item.");
        Console.WriteLine("[C] Change an item.");
        Console.WriteLine("[R] Remove all items.");

        string UserChoice = Console.ReadLine() ?? "";

        switch (UserChoice.ToUpper())
        {
            case "D":
                DeleteFromMenuCard();
                break;
            case "R":
                DeleteAllItemsFromMenuCard();
                break;
                
        }



        
    }
}

