using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maraton2.Clases;

namespace Maraton2
{
    class Program 
    {
        static void Main(string[] args)
        {
            try
            {
                List<SistemasIrrigacion> sistemas = new List<SistemasIrrigacion>();
                string line,SI="";
                System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\test.txt");
                line = file.ReadLine();
                while (line.CompareTo("9999 9999 9999")!=0)
                {
                    if (line.CompareTo("*") == 0)
                    {
                        //Creacion objeto
                        sistemas.Add(new SistemasIrrigacion(SI));
                        SI = "";
                        line = "";
                    }
                    if(SI.CompareTo("")!=0) SI += "+";
                    SI += line ;
                    line = file.ReadLine();
                }
                for(int i=0;i<sistemas.Count;i++)
                {
                    Console.WriteLine("Sistema Irrigacion "+(i+1)+"\n");
                    for(int j = 0; j < sistemas[i].Configuraciones.Length; j++)
                    {
                        Console.WriteLine(sistemas[i].calcularFlujos(j));
                    }
                    Console.WriteLine("");
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
