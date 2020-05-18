using System;

namespace _5Lab
{
    class Truck : Car
    {
        public int Capacity { get; set; }
        public override void Upgrade(int coef)
        {
            Capacity *= coef;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format(" CAPACITY : {0}", Capacity));
        }

        public override void Sign()
        {
            Console.WriteLine("pjjjjjjj\n");
        }

        public Truck(double mileAge, int maxSpeed, string country, string hand, double expense,
            double fuel, string fuelType, int horsePower, int capacity) : base(mileAge, maxSpeed, country, hand, expense, fuel, fuelType, horsePower)
        {
            Capacity = capacity;
        }
        public Truck(string hand, double expense, double fuel, string fuelType, int horsePower, int capacity) : base(hand, expense, fuel, fuelType, horsePower)
        {
            Capacity = capacity;
        }
        public Truck(int maxSpeed, string country, string hand, double expense, double fuel,
            string fuelType, int horsePower, int capacity) : base(maxSpeed, country, hand, expense, fuel, fuelType, horsePower)
        {
            Capacity = capacity;
        }
    }
}
