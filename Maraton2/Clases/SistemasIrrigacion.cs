using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2.Clases
{
    class SistemasIrrigacion
    {
        private Valvula[] valvulas;
        private Entrada[] entradas;
        private Salida[] salidas;
        private ConfiguracionValvulas[] configuraciones;

        public SistemasIrrigacion()
        {
        }

        public SistemasIrrigacion(string SI)
        {
            string[] aux = SI.Split('+');
            string[] tamaños = aux[0].Split(' ');
            string[] flujos = aux[1].Split(' ');
            entradas = new Entrada[Convert.ToInt32(tamaños[0])];
            salidas = new Salida[Convert.ToInt32(tamaños[1])];
            valvulas = new Valvula[Convert.ToInt32(tamaños[2])];
            //Se suben la entradas
            for(int i = 2; i < entradas.Length+2; i++)
            {
                string[] entr = aux[i].Split(' ');
                entradas[i - 2] = new Entrada(entr[0], Convert.ToDouble(flujos[i - 2]), entr[0]);
            }
            for (int i = 2+ entradas.Length ; i < 2 + entradas.Length+salidas.Length; i++)
            {
                salidas[i - 2 - entradas.Length] = new Salida(aux[i]);
            }
            for (int i = 2 + entradas.Length+salidas.Length; i < 2 + entradas.Length + salidas.Length +valvulas.Length; i++)
            {
                string[] val = aux[i].Split(' ');
                valvulas[i - 2 - entradas.Length - salidas.Length] = new Valvula(val[0], val[1], val[2]);
            }
            for (int i = 2 + entradas.Length + salidas.Length+ valvulas.Length; i < aux.Length; i++)
            {
                configuraciones[i - 2 - entradas.Length - salidas.Length - valvulas.Length] = new ConfiguracionValvulas(aux[i]);
            }
        }

        public string Imprimir()
        {
            string salida = "Entradas:\n";
            foreach(Entrada i in entradas)
            {
                salida +=i.Nombre+" "+i.Flujo+" "+i.NombreValvulaSalida+ "\n";
            }
            foreach (Salida i in salidas)
            {
                salida += i.Nombre + "\n";
            }
            foreach(Valvula i in valvulas)
            {
                salida += i.Nombre+ " " + i.ConfDerecha + " " + i.ConfIzquierda + "\n";
            }
            foreach(ConfiguracionValvulas i in configuraciones)
            {
                salida += i.imprimir()+"\n";
            }

            return salida;
        }
    }
}
