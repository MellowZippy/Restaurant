using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;



public class FoodLogic
{
    public static List<FoodModel> _foodList;
    public int foodCount { get { return _foodList.Count(); } } 

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

    public int GetLastId() 
    {
        if (_foodList.Count() == 0)
        {
            return 1;
        }
        else if (_foodList != null)
        {
            return _foodList.Last().Id + 1;
        }
        else
        {
            return 1;
        }
    }

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
    public FoodModel GetById(int id)
    {
        return _foodList.Find(i => i.Id == id)!;
    }

    public static void RearrangeIDs()
    {
        List<FoodModel> objects = JsonConvert.DeserializeObject<List<FoodModel>>(File.ReadAllText("DataSources/food.json"))!;

        int i = 0;

        foreach (FoodModel? foodItem in objects)
        {
            i++;
            foodItem.Id = i;
        }
        FoodAccess.WriteAll(objects);
    }

    public static void EditFoodItem(int id)
    {

        
        
        List<FoodModel> objects = JsonConvert.DeserializeObject<List<FoodModel>>(File.ReadAllText("DataSources/food.json"))!;

        foreach (FoodModel foodItem in objects)
        {
            if (foodItem.Id == id)
            {
                Console.WriteLine("What do you want to change about the item ?");
                Console.WriteLine("Write [N] to change the Name");
                Console.WriteLine("Write [P] to change the Price");
                Console.WriteLine("Write [D] to change the description");
                Console.WriteLine("Write [C] to change the category");
                Console.WriteLine("Write [B] to go back");
                string userinput = Console.ReadLine()!;
                switch (userinput.ToUpper()){
                    case "N":
                        Console.Clear();
                        MenuCard.ShowMenuCard();
                        Console.WriteLine("What name do you want to change it to ?");
                        string newname = Console.ReadLine();
                        foodItem.Name = newname;
                        break;
                    case "P":
                        Console.Clear();
                        MenuCard.ShowMenuCard();
                        Console.WriteLine("What price do you want to change it to ?");
                        int newprice = ReservationMenu.CheckIfInputIsInt();
                        foodItem.Price = newprice;
                        break;
                    case "D":
                        Console.Clear();
                        MenuCard.ShowMenuCard();
                        Console.WriteLine("What description do you want to change it to ?");
                        string newdescription = Console.ReadLine();
                        foodItem.Description = newdescription;
                        break;
                    case "C":
                        Console.Clear();
                        MenuCard.ShowMenuCard();
                        Console.WriteLine("What Category do you want to change it to ?");
                        string newcategory = Console.ReadLine();
                        foodItem.Category = newcategory;
                        break;
                    case "B":
                        MenuCard.ShowMenuOptions();
                        break;

                }
            
                FoodAccess.WriteAll(objects);
                EditFoodItem(id);
            }
        }



        
    }

}