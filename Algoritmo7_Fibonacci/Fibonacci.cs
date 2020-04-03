using System;
using System.Collections.Generic;
using System.Text;

namespace Algoritmo7_Fibonacci
{
    class Fibonacci
    {
        private long numeroSerie;
        private long numeroSerieAnterior;
        private long n;
        private long iterador;

        public Fibonacci()
        {
        }

        public Fibonacci(int n)
        {
            this.numeroSerieAnterior= 0;
            this.n = n;
            calcularFibonacci();

        }

        public long NumeroSerie { get => numeroSerie; set => numeroSerie = value; }
        public long N { get => n; set => n = value; }

        private void calcularFibonacci()
        {
            long aux;
            numeroSerie = 0;
            numeroSerieAnterior=1;
            for (long i= 0; i < n; i++)
            {
                aux = numeroSerie;
                numeroSerie = numeroSerieAnterior;
                numeroSerieAnterior = aux + numeroSerie;
            }
            
        }
        private long[] calcularFibonacciDESC()
        {
            long[] result = new long[n];
            long aux;
            numeroSerie = 0;
            numeroSerieAnterior = 1;
            for (int i = 0; i < n; i++)
            {
                aux = numeroSerie;
                numeroSerie = numeroSerieAnterior;
                numeroSerieAnterior = aux + numeroSerie;
                result[i] = numeroSerie;
            }
            long[] desc=new long[n];
            for (int i = 0; i < n; i++) { desc[i] = result[n - i - 1]; }
            return desc;
        }
        public string imprimir()
        {
            string result = "Estos son los " + n + " numeros de Fibonacci en orden descendente\n";
            foreach (long i in this.calcularFibonacciDESC())
            {
                result += " | " + i;
            }

            return result;
        }
    }
}
