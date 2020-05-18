using _5Lab;
using System;
using System.Collections.Generic;

namespace _6Lab
{
    class CompareByHorsePower : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {
            return x.Engine.HorsePower.CompareTo(y.Engine.HorsePower);
        }
    }

    class CompareBySpeed : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var parking = new List<Car>
            {
                new Сabriolet(123, "Frence", "Left", 12.3, 124, "Disel", 303, 34),
                new Truck(34, "Brazil", "Right", 32.1, 432, "Disel", 700, 1000),
                new Formula1(1, 567, "Germany", "Left", 54, 100, "Electro", 654, true, 22)
            };

            foreach (ISignalable car in parking)
            {
                Console.WriteLine(car.GetType());
                car.Sign();
            }

            parking.Sort(new CompareBySpeed());

            foreach (ISignalable car in parking)
            {
                Console.WriteLine(car.GetType());
                car.Sign();
            }

            parking.Sort(new CompareByHorsePower());

            foreach (ISignalable car in parking)
            {
                Console.WriteLine(car.GetType());
                car.Sign();
            }
        }
    }
}
