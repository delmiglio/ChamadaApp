using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = DateTime.Now.ToShortTimeString();

            string dia;

            Console.WriteLine(time);

            

            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            dia = dtfi.GetDayName(DateTime.Now.DayOfWeek);

            Console.WriteLine(dia.ToUpper().Substring(0, 3));

            Console.ReadLine();
        }
    }
}
