using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cadena = "", clave = "";
                Console.WriteLine("Ingrese la cadena");
                cadena = Console.ReadLine();
                Console.WriteLine("Ingrese la palabra clave");
                clave = Console.ReadLine();
                Console.WriteLine("\nEl resultado de la comparacion es: " + StringP.CompararCadenas(cadena, clave));
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error general: " + e.Message);
                Console.ReadKey();
            }
        }
        public class StringP
        {
            public static int CompararCadenas(string cadena, string clave)
            {
                cadena = cadena.ToUpper();
                clave = clave.ToUpper();
                //1 contendida
                if (cadena.Contains(clave)) return 1;

                //2 contenida pero separada
                int nroCaracteres=0;
                int j = 0;
                for(int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i].Equals(clave[j])) { j++;nroCaracteres++; }
                }
                if (nroCaracteres == clave.Length) return 2;

                //3 contenida pero al reves
                clave = StringP.InvertirManualmente(clave);
                if (cadena.Contains(clave)) return 3;

                //4 contenida al reves separada
                nroCaracteres = 0;
                j = 0;
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i].Equals(clave[j])) { j++; nroCaracteres++; }
                }
                if (nroCaracteres == clave.Length) return 4;

                //0 su es cualquier cosa
                return 0;
            }
            public static string InvertirManualmente(string cadena)
            {
                string cadenaInvertida = "";
                // Recorrer cadena letra por letra
                foreach (char letra in cadena)
                {
                    // Anteponer la letra a la cadena invertida
                    cadenaInvertida = letra + cadenaInvertida;
                }
                return cadenaInvertida;
            }
        }
        
    }
}
