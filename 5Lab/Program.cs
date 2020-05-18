using System;
using System.Collections.Generic;

namespace _5Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new List<Car>
            {
                new Сabriolet(123,"French","Left",12.3,124,"Disel",123,34),
                new Truck("Right",32.1,432,"Disel",432,1000),
                new Formula1("Left",54,100,"Electro",654,true,22)
            };

            foreach (Car car in parking)
            {
                Console.WriteLine(car);
                car.Upgrade(2);
                Console.WriteLine(car + "\n");
            }
        }
    }
}
