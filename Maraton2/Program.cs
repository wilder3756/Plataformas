using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2
{
    class Program 
    {
        static void Main(string[] args)
        {
            try
            {

                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\test.txt");
                line = file.ReadLine();
                while (line.CompareTo("9999 9999 9999")!=0)
                {
                    Console.WriteLine(line);
                    line = file.ReadLine();
                }


                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("El error es: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
