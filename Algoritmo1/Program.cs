using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algoritmo1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            }
            catch(Exception e)
            {
                Console.WriteLine("Error general" + e.Message);
                Console.ReadKey();
            }
            long nroInferior = 0, nroSuperior = 0;
            int nroHilos=0;
            Console.WriteLine("Ingrese el limite inferior");
            nroInferior = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Ingrese el limite superior");
            nroSuperior = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Ingrese La cantidad de hilos(1-8)");
            nroHilos = Convert.ToInt32(Console.ReadLine());

            if(!(nroInferior>=nroSuperior || nroHilos<1 || nroHilos > 8))
            {
                long re = calcularNuemeroPrimos(nroInferior, nroSuperior);
                Console.WriteLine("El numero de primos en el intervalo "+ nroInferior+", "+nroSuperior+" es: "+ calcularNuemeroPrimos(nroInferior,nroSuperior))
                
            }
            else
            {
                Console.WriteLine("Violacion de parametros");
            }
            Console.ReadKey();


        }
        public  long calcularNuemeroPrimos(long nroInferior,long nroSuperior)
        {
            long nroPrimos = 0;
            while (nroInferior < nroSuperior)
            {
                if (esPrimo(nroInferior)) nroPrimos++;
                nroInferior++;
            }
            return nroPrimos;
        }
        private bool esPrimo(long numero)
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
            return true;
        }

    }
}
