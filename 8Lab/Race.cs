using _5Lab;
using System;

namespace _8Lab
{
    static class Race
    {
        public delegate void RaceHandler();
        public static event RaceHandler race;
        public static void RaceOnDistance(double distance, params Car[] cars)
        {
            if (cars.Length == 0 || cars == null)
            {
                Console.WriteLine("no cars");
                return;
            }
            Car c = cars[0];
            race += c.Win;
            for (int i = 1; i < cars.Length; i++)
            {
                if (cars[i].MaxSpeed >= c.MaxSpeed && cars[i].FuelAmount / cars[i].ExpensesPerMile >= distance)
                {
                    race -= c.Win;
                    race += c.Lose;
                    c = cars[i];
                    race += c.Win;
                }
                else
                {
                    race += cars[i].Lose;
                }
            }

            race?.Invoke();
        }
    }
}
