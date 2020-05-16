using System;

namespace _7Lab
{

    class Program
    {
        static void Main(string[] args)
        {
            Fraction fr = new Fraction(7, 6);
            Fraction tr = new Fraction(-2, 3);
            Console.WriteLine(fr.ToString());
            Console.WriteLine(fr.ToString("long",null));
            Console.WriteLine(fr.ToString("double", null));

            Console.WriteLine("\nMath\n");
            Console.WriteLine($"fr + tr = {tr + fr}");
            Console.WriteLine($"fr - tr = {tr - fr}");
            Console.WriteLine($"fr / tr = {tr / fr}");
            Console.WriteLine($"fr * tr = {tr * fr}");
            Console.WriteLine($"fr > tr  {tr > fr}");
            Console.WriteLine($"fr < tr  {tr < fr}");
            Console.WriteLine($"fr == tr  {tr == fr}");
            Console.WriteLine($"fr != tr  {tr != fr}");
            Console.WriteLine($"fr <= tr  {tr <= fr}");
            Console.WriteLine($"fr >= tr  {tr >= fr}");
            Console.WriteLine($"++fr ={++fr}");
            Console.WriteLine($"--tr ={--tr}");
            try
            {
                Console.WriteLine($"tr / (0,5) ={tr / new Fraction(0,5)}");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"tr.Equals(fr) = {tr.Equals(fr)}");
            Console.WriteLine($"tr.CompareTo(fr) = {tr.CompareTo(fr)}");

            Console.WriteLine("\nCasts\n");
            Console.WriteLine($"(int)fr = {(int)fr}");
            Console.WriteLine($"(long)fr = {(long)fr}");
            Console.WriteLine($"(float)fr = {(float)fr}");
            Console.WriteLine($"(double)fr = {(double)fr}");
            Console.WriteLine($"(decimal)fr = {(decimal)fr}");

            int x = 22;
            fr = x;
            Console.WriteLine(fr);
            long l = 33;
            fr = l;
            Console.WriteLine(fr);
            float f = 1.2f;
            fr = f;
            Console.WriteLine(fr);
            double d = 2.3;
            fr = d;
            Console.WriteLine(fr);
            decimal m = 3.3M;
            fr = m;
            Console.WriteLine(fr);

            Console.WriteLine(Fraction.Parse("12/123"));
            Console.WriteLine(Fraction.Parse("12"));
            Console.WriteLine(Fraction.Parse("3,4"));
        }
    }
}
