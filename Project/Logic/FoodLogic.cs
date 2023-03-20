using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;



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

    public void MenuSeeder(List<FoodModel> foodList)
    {
        // W.I.P
    }

    public FoodModel GetById(int id)
    {
        return _foodList.Find(i => i.Id == id);
    }
}