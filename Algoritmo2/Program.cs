using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo2
{
    class Program
    {
        public static long nroPrimoN = 417;
        static void Main(string[] args)
        {
            try
            {
                
                Primo aux = new Primo();
                long nroPrimos = 0, nroPrimoFinal=0, nroIterativo=1;
                while (nroPrimos <= nroPrimoN)
                {
                    if (aux.asignarNumero(nroIterativo))
                    {
                        nroPrimos++;
                        nroPrimoFinal = nroIterativo;
                    }
                    nroIterativo++;
                }
                Console.WriteLine("El numero Primo Numero " + nroPrimoN + " es: " + nroPrimoFinal);
                Console.ReadKey();

            }
            catch(Exception e)
            {
                Console.WriteLine("error general" + e.Message);
                Console.ReadKey();
            }
        }

        public class Primo
        {
            private long numero;

            public Primo()
            {
               
            }

            public bool asignarNumero(long numero)
            {
                long divisor = 2;
                long resto = 0;
                while (divisor < numero)
                {
                    resto = numero % divisor;
                    if (resto == 0)
                    {
                        return false;
                    }
                    divisor = divisor + 1;
                }
                this.numero = numero;
                return true;
            }

            
        }
    }
}
