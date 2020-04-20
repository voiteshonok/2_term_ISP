using System;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select the option :\n" +
                    "1. Realize effective mixing of the characters of the string.\n" +
                    "2. Display month names in any language.\n" +
                    "3. Given a string with words separated by spaces.\nThere are punctuation marks that are written immediately after the word. Add the punctuation mark after each word.");
                switch (Console.ReadLine())
                {
                    case "1":
                        ShuffleClass shaf = new ShuffleClass();
                        shaf.MyShuffleProgram();
                        break;
                    case "2":
                        MonthClass mon = new MonthClass();
                        mon.MyMonthProgram();
                        break;
                    case "3":
                        PunctionClass punct = new PunctionClass();
                        punct.MyPunctionProgram();
                        break;
                    default:
                        Console.WriteLine("bad input");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
