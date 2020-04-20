using System;

namespace ConsoleAppTest
{
    class PunctionClass
    {
        public void MyPunctionProgram()
        {
            Console.WriteLine("Input a string");
            string str = Console.ReadLine();
            if (String.IsNullOrEmpty(str))
            {
                Console.WriteLine("bad input");
            }
            else
            {
                Console.WriteLine(Punction(str));
            }
        }

        string Punction(string str)
        {
            string[] splitted = str.Split(' ');
            for (int i = 0; i < splitted.Length; i++)
            {
                if (splitted[i].Length > 0 && Char.IsPunctuation(splitted[i][splitted[i].Length - 1]))
                {
                    splitted[i] = splitted[i][splitted[i].Length - 1] + splitted[i];
                }
            }
            string newStr = splitted[0];
            for (int i = 1; i < splitted.Length; i++)
            {
                newStr += " " + splitted[i];
            }
            return newStr;
        }
    }
}
