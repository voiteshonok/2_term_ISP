using System;
using System.Collections.Generic;

namespace _3Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Transport>
            {
                new Transport(),
                new Transport(32, "Germany"),
                new Transport(1234, 345, "USA")
            };
            while (true)
            {
                Console.WriteLine("1.Print all\n" +
                                  "2.Add new transport\n" +
                                  "3.Delete transport by index\n" +
                                  "4.Exit");
                if (int.TryParse(Console.ReadLine(), out int option) && option >= 1 && option <= 4)
                {
                    switch (option)
                    {
                        case 1:
                            {
                                foreach (var tr in list)
                                {
                                    Console.WriteLine(tr);

                                }
                                break;
                            }
                        case 2:
                            {
                                var strings = Console.ReadLine().Split(' ');
                                if (strings.Length == 3)
                                {
                                    try
                                    {
                                        list.Add(new Transport(Convert.ToDouble(strings[0]), Convert.ToInt32(strings[1]), strings[2]));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                else if (strings.Length == 2)
                                {
                                    try
                                    {
                                        list.Add(new Transport(Convert.ToInt32(strings[0]), strings[1]));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                                else
                                {
                                    list.Add(new Transport());
                                }
                                break;
                            }
                        case 3:
                            {
                                if (int.TryParse(Console.ReadLine(), out int del) && del >= 0 && del <= list.Count)
                                {
                                    list.RemoveAt(--del);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input\n");
                                }
                                break;
                            }
                        case 4:
                            {
                                return;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input\n");
                    continue;
                }
            }
        }
    }
}
