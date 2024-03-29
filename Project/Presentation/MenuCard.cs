using Newtonsoft.Json;

public static class MenuCard
{
    public static FoodLogic _foodLogic = new FoodLogic();

    public static void ShowMenuCard()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("THE MENU".PadLeft(260, ' '));
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;

        string json = File.ReadAllText("DataSources/food.json");
        List<FoodModel> foodList = JsonConvert.DeserializeObject<List<FoodModel>>(json);
        foreach (FoodModel foodItem in foodList)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {foodItem.Id.ToString().PadLeft(2, '0')} | {foodItem.Name.PadLeft(20, '-')} | ${foodItem.Price.ToString().PadLeft(10, '-')} | {foodItem.Description.PadLeft(100, '-')} |");

        }
        Console.ForegroundColor = ConsoleColor.White;
        Menu.PressEnter();
        BackToMenu();
    }

    public static void BackToMenu()
    {
        if (AccountsLogic.CurrentAccount != null) Menu.HandleLogin();
        else ForeGround.ForeGroundStartScreen();
    }

    public static void DeleteFromMenuCard()
    {
        Console.WriteLine("What item do you want to remove?");
        Console.Write("ID: ");
        int choiceUser = ReservationMenu.CheckIfInputIsInt();

        DeleteItemFromMenu(choiceUser);

        FoodLogic.RearrangeIDs();
    }

    public static void DeleteItemFromMenu(int id)
    {
        List<FoodModel> objects = JsonConvert.DeserializeObject<List<FoodModel>>(File.ReadAllText("DataSources/food.json"))!;

        FoodModel objectToRemove = objects.Find(o => o.Id == id)!;

        if (objectToRemove != null)
        {
            objects.Remove(objectToRemove);
        }
        File.WriteAllText("DataSources/food.json", JsonConvert.SerializeObject(objects));
    }

    /*
        public static void DeleteItemFromMenu(int id)
    {
        foreach (FoodModel foodItem in FoodLogic._foodList)
        {
            if (foodItem.Id == id)
            {
                FoodLogic._foodList.Remove(foodItem);
                FoodAccess.WriteAll(FoodLogic._foodList);
            }
        }
    }
    */


    public static void DeleteAllItemsFromMenuCard()
    {
        FoodLogic._foodList = new List<FoodModel>();
        FoodAccess.WriteAll(FoodLogic._foodList);
    }

    public static void AddItemToMenu()
    {
        Console.WriteLine("What will be the name of the dish?");
        string DishName = Console.ReadLine() ?? "";
        Console.WriteLine("What will be the price of the dish?");
        int DishPrice = ReservationMenu.CheckIfInputIsInt();
        Console.WriteLine("How will the food be described?");
        string DishDescription = Console.ReadLine() ?? "";
        Console.WriteLine("What category of food does this dish belong to?");
        string DishCategory = Console.ReadLine() ?? "";

        int id = _foodLogic.GetLastId();

        FoodModel foodModel = new FoodModel(id, DishName, DishPrice, DishDescription, DishCategory);

        _foodLogic.UpdateList(foodModel);
        AdminMenu.AdminUI();
    }

    public static void ShowMenuOptions()
    {
        Console.WriteLine("What do you want to do with the menu?");
        Console.WriteLine("[D] Delete an item.");
        Console.WriteLine("[C] Change an item.");
        Console.WriteLine("[R] Remove all items.");
        Console.WriteLine("[A] Add an item to the menu");
        Console.WriteLine("[B] Go back");

        string UserChoice = Console.ReadLine()!;

        switch (UserChoice.ToUpper())
        {
            case "D":
                DeleteFromMenuCard();
                break;
            case "R":
                DeleteAllItemsFromMenuCard();

                break;
            case "A":
                AddItemToMenu();
                break;
            case "C":
                ShowMenuCard();
                Console.WriteLine("What id would you like to change ?");
                int id = ReservationMenu.CheckIfInputIsInt();
                FoodLogic.EditFoodItem(id);
                break;
            case "B":
                AdminMenu.AdminUI();
                break;



        }

    AdminMenu.AdminUI();
    }
}

