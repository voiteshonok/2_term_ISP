using System;
using System.Runtime.InteropServices;

namespace _2Task
{
    class Native
    {
        [DllImport("MyDll.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int sum(int a, int b);
        [DllImport("MyDll.dll", EntryPoint = "abbs", CallingConvention = CallingConvention.Cdecl)]
        public static extern int abbs(int n);
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Input a and b");
            var str = Console.ReadLine().Split(" ");
            int a = Convert.ToInt32(str[0]), b = Convert.ToInt32(str[1]);

            Console.WriteLine($"sum of a={a} and b={b} is {Native.sum(a, b)} and abs of sum is {Native.abbs(Native.sum(a, b))}");
        }
    }
}
