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

            DateTime dia = new DateTime();

            Console.WriteLine(time);

            Console.WriteLine(dia.ToString("ddd").ToUpper(), new CultureInfo("pt-br"));

            Console.ReadLine();
        }
    }
}
