class FoodLogic
{
    private List<FoodModel> _foodList;

    public FoodLogic()
    {
        _foodList = FoodAccess.LoadAll();
    }

    public void UpdateList(FoodModel food)
    {
        //Find if there is already an model with the same id
        int index = _foodList.FindIndex(s => s.Id == food.Id);

        if (index != -1)
        {
            //update existing model
            _foodList[index] = food;
        }
        else
        {
            //add new model
            _foodList.Add(food);
        }
        FoodAccess.WriteAll(_foodList);
    }

    public int GetLastId() => _foodList.Last().Id;

    public void MenuSeeder(List<FoodModel> foodList)
    {
        foreach (FoodModel foodItem in foodList)
        {
            UpdateList(foodItem);
            Console.WriteLine($"{foodItem.Name} added to the menu!");
        }
    }

    public List<String> GetAllCategories()
    {
        List<String> Categories = new List<String>();

        List<FoodModel> foodList = FoodAccess.LoadAll();
        foreach(FoodModel foodItem in foodList)
        {
            Categories.Add(foodItem.Category);
        }

        return Categories.Distinct().ToList();
    }

    /*
    public List<FoodModel> FileToFoodList(string path)
    {
        List<FoodModel> foodList = new List<FoodModel>();

        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path);
            string contents = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
        }


        return foodList;
    }
    */

    public FoodModel GetById(int id)
    {
        return _foodList.Find(i => i.Id == id)!;
    }
}