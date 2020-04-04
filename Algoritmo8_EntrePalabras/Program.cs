using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo8_EntrePalabras
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inicio = "", final = "", intermedio = "";
                Console.Write("Ingrese la palabra inicial -->");
                inicio = Console.ReadLine();
                Console.Write("Ingrese la palabra final -->");
                final = Console.ReadLine();
                Console.Write("Ingrese la palabra -->");
                intermedio = Console.ReadLine();
                EntrePalabra ePalabra = new EntrePalabra(inicio, final);
                bool i = ePalabra.comprobarPalabra(intermedio);
                if (i) Console.WriteLine("La cadena esta entre inicio y final: " + inicio + " -- " + intermedio + " -- " + final);
                else Console.WriteLine("La cadena  NO esta entre inicio y final: " + inicio + " -- " + intermedio + " -- " + final);
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error General: " + e.Message);
                Console.ReadKey();
            }
        }

        public class EntrePalabra
        {
            private string inicio;
            private string final;

            public EntrePalabra(string inicio, string final)
            {
                this.inicio = inicio ?? throw new ArgumentNullException(nameof(inicio));
                this.final = final ?? throw new ArgumentNullException(nameof(final));
            }

            public string Inicio { get => inicio; set => inicio = value; }
            public string Final { get => final; set => final = value; }

            public bool comprobarPalabra(string palabra)
            {
                char[] cadenaInicio = inicio.ToLower().ToCharArray();
                char[] cadenaFinal = final.ToLower().ToCharArray();
                char[] cadenaIntermedia = palabra.ToLower().ToCharArray();

                int length = (cadenaInicio.Length < cadenaFinal.Length) ? cadenaInicio.Length : cadenaFinal.Length;
                for(int i = 0; i < length; i++)
                {
                    if (i == cadenaFinal.Length || i == cadenaInicio.Length || i == cadenaIntermedia.Length) return false;
                    if (cadenaInicio[i] == cadenaIntermedia[i] && cadenaIntermedia[i] == cadenaIntermedia[i]) continue;
                    else if (cadenaIntermedia[i] < cadenaFinal[i] && cadenaIntermedia[i] > cadenaInicio[i]) return true;
                    else if (cadenaIntermedia[i] < cadenaFinal[i] && cadenaFinal[i] < cadenaInicio[i]) return true;
                    else if (cadenaIntermedia[i] < cadenaFinal[i] && cadenaFinal[i] < cadenaInicio[i]) return true;
                    else return false;

                }
                return false;

            }
        }
    }
}
