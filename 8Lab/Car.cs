using System;

namespace _5Lab
{

    abstract class Car : _3Lab.Transport, _6Lab.ISignalable
    {
        public delegate void Message(string str);
        public event Message IWin;
        public event Message ILose;
        public EngineCharacters Engine { get; protected set; }
        public DriveHand Hand { get; protected set; }
        protected double fuelAmount;
        public double FuelAmount
        {
            get { return fuelAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    fuelAmount = value;
                }
            }
        }
        protected double expensesPerMile;
        public double ExpensesPerMile
        {
            get { return expensesPerMile; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    expensesPerMile = value;
                }
            }
        }
        public Car(double mileAge, int maxSpeed, string country, string hand, double expense,
            double fuel, string fuelType, int horsePower) : base(mileAge, maxSpeed, country)
        {
            Hand = (DriveHand)(Enum.Parse(typeof(DriveHand), hand));
            ExpensesPerMile = expense;
            FuelAmount = fuel;
            Engine = new EngineCharacters(fuelType, horsePower);
        }
        public Car(string hand, double expense, double fuel, string fuelType, int horsePower) : base()
        {
            Hand = (DriveHand)(Enum.Parse(typeof(DriveHand), hand));
            ExpensesPerMile = expense;
            FuelAmount = fuel;
            Engine = new EngineCharacters(fuelType, horsePower);
        }
        public Car(int maxSpeed, string country, string hand, double expense, double fuel,
            string fuelType, int horsePower) : base(maxSpeed, country)
        {
            Hand = (DriveHand)(Enum.Parse(typeof(DriveHand), hand));
            ExpensesPerMile = expense;
            FuelAmount = fuel;
            Engine = new EngineCharacters(fuelType, horsePower);
        }

        public abstract void Upgrade(int coef);

        public void FuelUp(int up)
        {
            FuelAmount += up;
        }

        public override void Run(double mile)
        {
            mile = Math.Max(FuelAmount / ExpensesPerMile, mile);
            FuelAmount -= mile / ExpensesPerMile;
            base.Run(mile);
        }

        public void Win()
        {
            IWin?.Invoke($"Id : {Id} and I won yrraaaa");
        }

        public void Lose()
        {
            ILose?.Invoke($"Id : {Id} and I lose shit happens");
        }

        /*public void getRace()
        {

        }*/


        public override string ToString()
        {
            return string.Concat(base.ToString(),
                string.Format(" ENGINE : {0} {1} HAND : {2} EXEPENSEPERMILE : {3}", Engine.EngineType, Engine.HorsePower, Hand, ExpensesPerMile));
        }

        public abstract void Sign();

        public enum TypesOfEngine { Disel, Electro };
        public enum DriveHand { Left, Right };
        public struct EngineCharacters
        {
            public EngineCharacters(string fuelType, int horsePower)
            {
                EngineType = (TypesOfEngine)(Enum.Parse(typeof(TypesOfEngine), fuelType));
                HorsePower = horsePower;
            }
            public TypesOfEngine EngineType { get; set; }
            public int HorsePower { get; set; }
        }
    }
}
