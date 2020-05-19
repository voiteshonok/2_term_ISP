using _5Lab;
using System;
using System.Collections.Generic;

namespace _8Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new List<Car>
            {
                new Сabriolet(123, "Frence", "Left", 12.3, 124, "Disel", 303, 34),
                new Truck(34, "Brazil", "Right", 32.1, 432, "Disel", 700, 1000),
                new Formula1(345,"Belarus","Left",4.3,564,"Disel",344,23)
            };

            try
            {
                parking.Add(new Truck(-32, "Belarus", "Right", 1.2, 34, "Disel", 43, 124));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach(Car car in parking)
            {
                car.IWin += (str) => Console.WriteLine(str);
                car.ILose += (str) => Console.WriteLine(str);
            }

            Race.RaceOnDistance(12, parking[2], parking[0], parking[1]);
        }
    }
}
