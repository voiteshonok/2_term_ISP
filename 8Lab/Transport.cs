using System;

namespace _3Lab
{
    public class Transport
    {
        private static int _id;
        public int Id { get; protected set; }
        public string ManufactureCountry { get; protected set; }
        protected double mileAge;
        public double MileAge
        {
            get { return mileAge; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    mileAge = value;
                }
            }
        }

        protected int maxSpeed;
        public int MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    maxSpeed = value;
                }
            }
        }

        static Transport()
        {
            _id = 0;
        }

        public Transport(double mileAge, int maxSpeed, string country)
        {
            this.MileAge = mileAge;
            this.MaxSpeed = maxSpeed;
            this.ManufactureCountry = country;
            this.Id = ++_id;
        }

        public Transport()
        {
            this.MileAge = 0;
            this.MaxSpeed = 250;
            this.ManufactureCountry = "unknown";
            this.Id = ++_id;
        }

        public Transport(int maxSpeed, string country) : this(0, maxSpeed, country)
        {
        }

        public virtual void Run(double mile)
        {
            MileAge += mile;
        }

        public override string ToString()
        {
            return string.Format("ID : {0} MILIAGE : {1} MAXSPEED : {2} FROM : {3}", Id, MileAge, MaxSpeed, ManufactureCountry);
        }
    }
}
