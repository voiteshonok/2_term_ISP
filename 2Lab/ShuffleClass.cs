using System;
using System.Text;

namespace ConsoleAppTest
{
    class ShuffleClass
    {
        public void MyShuffleProgram()
        {
            Console.WriteLine("Input a string");
            string str = Console.ReadLine();
            if (String.IsNullOrEmpty(str))
            {
                Console.WriteLine("bad input");
            }
            else
            {
                Console.WriteLine(Shuffle(str));
            }
        }

        string Shuffle(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            Random rand = new Random();
            for (int i = 0; i < sb.Length; i++)
            {
                int j = rand.Next(sb.Length);
                (sb[i], sb[j]) = (sb[j], sb[i]);
            }
            return sb.ToString();
        }
    }
}
