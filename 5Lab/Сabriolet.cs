namespace _5Lab
{
    class Сabriolet : Car
    {
        public int BeatyPoints { get; set; }
        public bool HasNoRoof { get; set; }
        public override void Upgrade(int coef)
        {
            BeatyPoints *= coef;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format(" BEATYPOINTS : {0} NOROOF : {1}", BeatyPoints, HasNoRoof));
        }

        public Сabriolet(double mileAge, int maxSpeed, string country, string hand, double expense,
            double fuel, string fuelType, int horsePower, bool hasNoRoof, int beatyPoints) : base(mileAge, maxSpeed, country, hand, expense, fuel, fuelType, horsePower)
        {
            HasNoRoof = hasNoRoof;
            BeatyPoints = beatyPoints;
        }
        public Сabriolet(string hand, double expense, double fuel, string fuelType, int horsePower, bool hasNoRoof, int beatyPoints) : base(hand, expense, fuel, fuelType, horsePower)
        {
            HasNoRoof = hasNoRoof;
            BeatyPoints = beatyPoints;
        }
        public Сabriolet(int maxSpeed, string country, string hand, double expense, double fuel,
            string fuelType, int horsePower, int beatyPoints) : base(maxSpeed, country, hand, expense, fuel, fuelType, horsePower)
        {
            HasNoRoof = true;
            BeatyPoints = beatyPoints;
        }
    }
}
