using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maraton1.Clases;

namespace Maraton1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string line;
                int n = 0;
                CalendarioHAAB calHAAB;
                CalendarioTzolkin calTzolkin;
                List<CalendarioTzolkin> calendarioTzolkins=new List<CalendarioTzolkin>();

                System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
                line = file.ReadLine();
                n = Int32.Parse(line);
                while (n>0)
                {
                    line = file.ReadLine();
                    string[] split=line.Split('.');
                    string[] split2 = split[1].Split(' ');
                    split2[0].Trim();
                    calHAAB = new CalendarioHAAB(Convert.ToInt32(split2[1]),split2[0],Convert.ToInt32(split[0]));
                    calTzolkin = calHAAB.convertirTzolkin();
                    calendarioTzolkins.Add(calTzolkin);
                    n--;
                }

                file.Close();
                System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"c:\salida.txt");
                foreach(CalendarioTzolkin i in calendarioTzolkins)
                {
                    file1.WriteLine(i.DiaNumero + ". " + i.DiaNombre + " " + i.Año);
                }

                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("El error es: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
