using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cadena="";
                char inicio , comienzo;
                Console.WriteLine("Ingrese la cadena:");
                cadena = Console.ReadLine();
                Console.WriteLine("\nParte 1");
                Console.WriteLine("Ingrese la letra de inicio:");
                inicio = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Ingrese la letra con la que comienza:");
                comienzo = Convert.ToChar(Console.ReadLine());
                Cifrador ejm = new Cifrador(cadena, inicio, comienzo);
                Console.WriteLine("La cadena original es: " + cadena + "    la cadena ya cifrada es: " + ejm.Cadena);

                Console.WriteLine("\n\nParte 2");
                Console.WriteLine("Ingrese la letra de inicio:");
                inicio = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Ingrese la letra con la que comienza:");
                comienzo = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("La cadena cifrada es: " + ejm.Cadena );
                ejm.decifrar(inicio,comienzo);
                Console.Write("la cadena ya decifrada es: " + ejm.Cadena+"\n");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error General:" + e.Message);
                Console.ReadKey();
            }
        }
            public class Cifrador
            {
                public static char[] abc = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'} ;
                private string cadena;

                public Cifrador(string cadena, char inicio,char comienzo)
                {
                    this.cadena = cadena.ToLower();
                    inicio = Convert.ToChar(inicio.ToString().ToLower());
                    comienzo = Convert.ToChar(comienzo.ToString().ToLower());
                    cifrar(inicio, comienzo);
                }

                public string Cadena { get => cadena; set => cadena = value; }

                public void cifrar(char inicio, char comienzo)
                {
                    int posiciones = 0;
                    string aux="";
                    if(Convert.ToInt32(inicio)< Convert.ToInt32(comienzo))posiciones = Convert.ToInt32(comienzo) - Convert.ToInt32(inicio);
                    else posiciones = Convert.ToInt32(inicio) - Convert.ToInt32(comienzo);
                    for(int i = 0; i < cadena.Length; i++)
                    {
                        char letra = cadena[i];
                        if (Convert.ToInt32(letra) + posiciones <= 122)
                        {
                            aux += Convert.ToString(Convert.ToChar(Convert.ToInt32(letra) + posiciones));
                        }
                        else
                        {

                            aux += Convert.ToString(Convert.ToChar(96+((Convert.ToInt32(letra) + posiciones)-122)));
                        }
                    }
                    this.cadena = aux;
                
                }
            public void decifrar(char inicio, char comienzo)
            {
                int posiciones = 0;
                string aux = "";
                if (Convert.ToInt32(inicio) < Convert.ToInt32(comienzo)) posiciones = Convert.ToInt32(comienzo) - Convert.ToInt32(inicio);
                else posiciones = Convert.ToInt32(inicio) - Convert.ToInt32(comienzo);

                for (int i = 0; i < cadena.Length; i++)
                {
                    char letra = cadena[i];
                    if (Convert.ToInt32(letra) - posiciones >=97)
                    {
                        aux += Convert.ToString(Convert.ToChar(Convert.ToInt32(letra) - posiciones));
                    }
                    else
                    {
                        Console.WriteLine(".");
                        aux += Convert.ToString(Convert.ToChar( 122 - (96-(Convert.ToInt32(letra) - posiciones))));
                    }
                }
                this.cadena = aux;
            }
            }
        
    }
}
