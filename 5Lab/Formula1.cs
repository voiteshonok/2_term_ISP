namespace _5Lab
{
    class Formula1 : Car
    {
        public bool IsRasing { get; set; }
        public int Nitro { get; set; }
        public override void Upgrade(int coef)
        {
            Nitro *= coef;
        }

        public override string ToString()
        {
            return string.Concat(base.ToString(), string.Format(" NITRO : {0} ISRACING : {1}", Nitro, IsRasing));
        }

        public Formula1(double mileAge, int maxSpeed, string country, string hand, double expense,
            double fuel, string fuelType, int horsePower, bool isRasing, int nitro) : base(mileAge, maxSpeed, country, hand, expense, fuel, fuelType, horsePower)
        {
            IsRasing = isRasing;
            Nitro = nitro;
        }
        public Formula1(string hand, double expense, double fuel, string fuelType, int horsePower, bool isRasing, int nitro) : base(hand, expense, fuel, fuelType, horsePower)
        {
            IsRasing = isRasing;
            Nitro = nitro;
        }
        public Formula1(int maxSpeed, string country, string hand, double expense, double fuel,
            string fuelType, int horsePower, int nitro) : base(maxSpeed, country, hand, expense, fuel, fuelType, horsePower)
        {
            IsRasing = true;
            Nitro = nitro;
        }
    }
}
