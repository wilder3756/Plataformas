using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo3
{
    class Program
    {
        static void Main(string[] args)
        {
            string varEntrada="";
            try
            {
                Console.Write("Ingrese el numero: ");
                varEntrada = Console.ReadLine();
                Numero numeroEntrada = new Numero(varEntrada);
                
                Console.WriteLine("Los numeros de entrada y salida son: " + numeroEntrada.Numero1 + "-" + numeroEntrada.devolverNumeroPalindromo());
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("El error general es: " + e.Message);
                Console.ReadKey();
            }
        }
        public class Numero
        {
            private string numero;

            public Numero(string numero)
            {
                this.numero = numero;
            }

            public string Numero1 { get => numero; set => numero = value; }

            public string devolverNumeroPalindromo()
            {
                string valorSalida = "";
                char[] aux = numero.ToCharArray();

                for (int i = aux.Length - 1; i >= 0; i--)
                {
                    //Console.WriteLine("°" + aux[i]);
                    valorSalida += Convert.ToString(aux[i]);
                }
                return valorSalida;
            }
        }
    }
}
