using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Reservation
{
    public string name { get; set; }
    public DateTime date { get; set; }
    public TimeSpan time { get; set; }
    public int num_guests { get; set; }
}

class ReservationSystem
{
    private List<Reservation> reservations = new List<Reservation>();

    public void add_reservation(string name, DateTime date, TimeSpan time, int num_guests)
    {
        Reservation reservation = new Reservation()
        {
            name = name,
            date = date,
            time = time,
            num_guests = num_guests
        };

        reservations.Add(reservation);
    }

    public void change_reservation(string name, DateTime new_date, TimeSpan new_time, int new_num_guests)
    {
        Reservation reservation = reservations.Find(r => r.name == name);

        if (reservation != null)
        {
            reservation.date = new_date;
            reservation.time = new_time;
            reservation.num_guests = new_num_guests;
        }
    }

    public void cancel_reservation(string name)
    {
        Reservation reservation = reservations.Find(r => r.name == name);

        if (reservation != null)
        {
            reservations.Remove(reservation);
        }
    }

    public List<Reservation> get_reservations()
    {
        return reservations;
    }
}

class Program2
{
    static void Main2(string[] args)
    {
        ReservationSystem reservationSystem = new ReservationSystem();

        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Make a reservation");
            Console.WriteLine("2. Change an existing reservation");
            Console.WriteLine("3. Cancel an existing reservation");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                // Make a reservation
                Console.WriteLine("Enter your full name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the date of the reservation (yyyy-MM-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter the time of the reservation (HH:mm): ");
                TimeSpan time = TimeSpan.Parse(Console.ReadLine());

                Console.WriteLine("Enter the number of guests: ");
                int num_guests = int.Parse(Console.ReadLine());

                reservationSystem.add_reservation(name, date, time, num_guests);

                // Write updated reservations to file
                string json = JsonSerializer.Serialize(reservationSystem.get_reservations());
                File.WriteAllText("reservation.json", json);

                Console.WriteLine("Reservation added successfully.");

            }
            else if (choice == 2)
            {
                // Change an existing reservation
                Console.WriteLine("Enter the name of the reservation to change: ");
                string change_name = Console.ReadLine();

                Console.WriteLine("Enter the new date of the reservation (yyyy-MM-dd): ");
                DateTime new_date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new time of the reservation (HH:mm): ");
                TimeSpan new_time = TimeSpan.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new number of guests: ");
                int new_num_guests = int.Parse(Console.ReadLine());

                reservationSystem.change_reservation(change_name, new_date, new_time, new_num_guests);

                // Write updated reservations to file
                string json = JsonSerializer.Serialize(reservationSystem.get_reservations());
                File.WriteAllText("reservation.json", json);

                Console.WriteLine("Reservation changed successfully.");

            }
            else if (choice == 3)
            {
                // Cancel an existing reservation
                Console.WriteLine("Enter the name of the reservation to cancel: ");
                string cancel_name = Console.ReadLine();

                reservationSystem.cancel_reservation(cancel_name);

                // Write updated reservations to file
                string json = JsonSerializer.Serialize(reservationSystem.get_reservations());
                File.WriteAllText("reservation.json", json);

                Console.WriteLine("Reservation canceled successfully.");

            }
            else if (choice == 4)
            {
                // Exit the program
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose again.");
            }
        }
    }
}