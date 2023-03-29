using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class ReservationsLogic
{
    private static List<ReservationModel> _reservations;

    public ReservationsLogic()
    {
        _reservations = ReservationsAccess.LoadAll();
    }


    public static void UpdateList(ReservationModel res)
    {
        //Find if there is already an model with the same id
        int index = _reservations.FindIndex(s => s.Id == res.Id);

        if (index != -1)
        {
            //update existing model
            _reservations[index] = res;
        }
        else
        {
            //add new model
            _reservations.Add(res);
        }
        ReservationsAccess.WriteAll(_reservations);

    }

    public ReservationModel GetById(int id)
    {
        return _reservations.Find(i => i.Id == id);
    }
}


