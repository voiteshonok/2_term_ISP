using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "input.txt";
            Console.WriteLine("Please write number of things and capacity of backpack and then n rows with ci wi");
            Console.WriteLine("as the example :\nn W\nc1 w1\nc2 w2\n...\ncn wn");

            if (!File.Exists(name))
            {
                Input(name);
            }
            Console.WriteLine("Are you ready?\nType smth if yes");
            Console.ReadKey();
            Console.Write("\n");

            while (!File.Exists(name) || !CheckFile(name))
            {
                Console.WriteLine("file does not exist or input is inapproprite try again");
                Input(name);
                Console.WriteLine("Are you ready?\nType smth if yes");
                Console.ReadKey();
                Console.Write("\n");
            }

            Solution(name);

            //File.Delete(name);
            Console.ReadKey();

        }

        static void Input(string name)
        {
            using (StreamWriter sc = File.CreateText(name)) { }

        }

        static bool CheckFile(string name)
        {
            bool ok = true;
            using (StreamReader scanner = File.OpenText(name))
            {
                string firstStr = scanner.ReadLine();
                if (!SplittedChech(firstStr))
                {
                    return false;
                }

                string[] splitted = firstStr.Split(' ');


                int n = Convert.ToInt32(splitted[0]);
                for (int i = 0; i < n; i++)
                {
                    firstStr = scanner.ReadLine();
                    if (!SplittedChech(firstStr))
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        static bool SplittedChech(string firstStr)
        {
            bool ok = true;

            if (firstStr == null || !firstStr.Contains(' '))
            {
                return false;
            }
            string[] splitted = firstStr.Split(' ');

            if (splitted.Length != 2)
            {
                ok = false;
            }
            foreach (var c in splitted[0])
            {
                if (c - '0' > 9 || c - '0' < 0)
                {
                    ok = false;
                }
            }
            foreach (var c in splitted[1])
            {
                if (c - '0' > 9 || c - '0' < 0)
                {
                    ok = false;
                }
            }
            return ok;
        }

        static void Solution(string name)
        {
            using (StreamReader scanner = File.OpenText(name))
            {
                string str = scanner.ReadLine();
                string[] splitted = str.Split(' ');
                int n = Convert.ToInt32(splitted[0]), W = Convert.ToInt32(splitted[1]);

                int[] value = new int[n + 1];
                int[] weight = new int[n + 1];
                int[,] dp = new int[W + 1, n + 1];

                for (int i = 1; i < n + 1; i++)
                {
                    str = scanner.ReadLine();
                    splitted = str.Split(' ');
                    value[i] = Convert.ToInt32(splitted[0]);
                    weight[i] = Convert.ToInt32(splitted[1]);
                }


                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < W + 1; j++)
                    {
                        dp[j, i] = dp[j, i - 1];
                        if (weight[i] <= j)
                        {
                            dp[j, i] = Max(dp[W - weight[i], i - 1] + value[i], dp[j, i]);
                        }
                    }
                }
                Console.WriteLine("total value = " + dp[W, n] +"\nNumbers of used things :");

                bool[] wasUsed = new bool[n + 1];
                int J = W, I = n;
                while (I > 0)
                {
                    if (dp[J, I] != dp[J, I - 1])
                    {
                        wasUsed[I] = true;
                        J -= weight[I];
                    }
                    I--;
                }
                for (int i = 1; i <= n; i++)
                {
                    if (wasUsed[i])
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }

        static int Max(int a, int b)
        {
            return a < b ? b : a;
        }
    }
}