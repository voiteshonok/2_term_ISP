using System;
using System.Globalization;
using System.Text;

namespace ConsoleAppTest
{
    class MonthClass
    {
        public void MyMonthProgram()
        {
            Console.WriteLine("input TwoLetterISOLanguageName");
            string str = Console.ReadLine().Trim().ToLowerInvariant();
            try
            {
                WriteMonths(str);
            }
            catch (Exception)
            {
                Console.WriteLine("bad input");
            }
        }

        void WriteMonths(string str)
        {
            CultureInfo culture = new CultureInfo(str);
            DateTime date = new DateTime(2020, 01, 01);
            Console.OutputEncoding = Encoding.UTF8;
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(date.ToString("MMMM", CultureInfo.GetCultureInfo(culture.ToString())));
                date = date.AddMonths(1);
            }
            Console.OutputEncoding = Encoding.Default;
        }
    }
}
