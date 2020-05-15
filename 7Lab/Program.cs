using System;

namespace _7Lab
{

    class Program
    {
        static void Main(string[] args)
        {
            Fraction fr = new Fraction(5, 6);
            Fraction tr = new Fraction(2, 3);
            Fraction q = new Fraction(-3);
            q++;
            Console.WriteLine((q).ToString());
            Console.WriteLine();

        }
    }
}
