using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int numero = 0;
                Romano numeroRomano;
                Console.WriteLine("Escriba un numero en el ranfo [1,100]");
                numero = Convert.ToInt32(Console.ReadLine());
                if (numero > 0 && numero <= 100)
                {
                    numeroRomano = new Romano(numero);
                    Console.WriteLine("Numero decimal: " + numero + "  Numero Romano: " + numeroRomano.Numero);
                }
                else Console.WriteLine("El numero debe estar en el rango [1,100]");

                Console.WriteLine("Termina la ejeccuccion");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
            }
        }

        public class Romano
        {
            private string numero;
            public static string[] numeros1_10 = new string[9] { "I","II","III", "IV","V", "VI", "VII", "VIII", "IX"};
            public static string[] numeros10_100 = new string[10] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC", "C", };
            public Romano(int numero)
            {
                if (numero > 0 && numero <= 100)
                {
                    if (numero > 0 && numero < 10)
                    {
                        this.numero = numeros1_10[numero - 1];
                    }
                    else if (numero >= 10 && numero < 100)
                    {
                        //Console.WriteLine(Convert.ToString(numero)[1]);
                        //Console.WriteLine(Convert.ToInt32(Convert.ToString(numero)[1]));
                        this.numero = numeros10_100[Convert.ToInt32(Convert.ToString(numero)[0]) - 49];
                        if(Convert.ToInt32(Convert.ToString(numero)[1]) != 48) { this.numero += numeros1_10[Convert.ToInt32(Convert.ToString(numero)[1]) - 49]; }
                        
                    }
                    else this.numero = numeros10_100[9];
                }
                else throw new Exception("el numero debe ser mayor a 0 y menor o igual a 100");
            }

            public string Numero { get => numero; set => numero = value; }
        }
    }
}
