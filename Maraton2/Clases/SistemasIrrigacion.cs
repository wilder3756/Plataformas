using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2.Clases
{
    class SistemasIrrigacion
    {
        public static bool derecha = true;
        public static bool izquierda = false;
        private Valvula[] valvulas;
        private Entrada[] entradas;
        private Salida[] salidas;
        private ConfiguracionValvulas[] configuraciones;

        internal Valvula[] Valvulas { get => valvulas; set => valvulas = value; }
        internal Entrada[] Entradas { get => entradas; set => entradas = value; }
        internal Salida[] Salidas { get => salidas; set => salidas = value; }
        public ConfiguracionValvulas[] Configuraciones { get => configuraciones; set => configuraciones = value; }

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
                entradas[i - 2] = new Entrada(entr[0], Convert.ToDouble(flujos[i - 2]), entr[1]);
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
            configuraciones = new ConfiguracionValvulas[aux.Length - (2 + entradas.Length + salidas.Length + valvulas.Length)];
            for (int i = 2 + entradas.Length + salidas.Length+ valvulas.Length; i < aux.Length; i++)
            {
                //Console.WriteLine(i - 2 - entradas.Length - salidas.Length - valvulas.Length);
                configuraciones[i - 2 - entradas.Length - salidas.Length - valvulas.Length] = new ConfiguracionValvulas(aux[i]);
            }
        }

        public string Imprimir()
        {
            string salida = "";
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

        public string calcularFlujos(int conf)
        {
            if (conf >= 0 && conf < configuraciones.Length)
            {
                string resultado="";
                double[] entr = new double[entradas.Length];
                for (int i = 0; i < entradas.Length; i++)
                {
                    entr[i]= entradas[i].Flujo;
                    foreach (Valvula j in valvulas)
                    {
                        if (entradas[i].NombreValvulaSalida.Equals(j.Nombre)) j.Flujo += entradas[i].Flujo;
                    }
                }
                
                
                for (int i = 0; i < valvulas.Length; i++)
                {
                    for (int j = 0; j < valvulas.Length; j++)
                    {
                        if (configuraciones[conf].ConfiguracionValculas[i] == derecha)
                        {
                            if (valvulas[i].ConfDerecha.Equals(valvulas[j].Nombre)) valvulas[j].Flujo = valvulas[i].Flujo;
                            for (int k = 0; k < salidas.Length; k++)
                            {
                                if (valvulas[i].ConfDerecha.Equals(salidas[k].Nombre)) salidas[k].Flujo = valvulas[i].Flujo;
                            }
                        }
                        else if (configuraciones[conf].ConfiguracionValculas[i] == izquierda)
                        {
                            if (valvulas[i].ConfIzquierda.Equals(valvulas[j].Nombre)) valvulas[j].Flujo = valvulas[i].Flujo;
                            for (int k = 0; k < salidas.Length; k++)
                            {
                                if (valvulas[i].ConfDerecha.Equals(salidas[k].Nombre)) salidas[k].Flujo = valvulas[i].Flujo;
                            }
                        }
                    }
                    foreach (Valvula j in valvulas)
                    {
                        Console.Write(j.Flujo + "|");
                    }
                    Console.WriteLine("");
                }

                resultado += "Configuracion de valvulas " + (conf + 1)+"\n";
                for (int k = 0; k < salidas.Length; k++)
                {
                    resultado += "Salida (" + salidas[k].Nombre + ") # " + (k + 1)+" : flujo "+ salidas[k].Flujo+"galones/minuto\n";
                }
                for (int i = 0; i < entradas.Length; i++)entradas[i].Flujo=entr[i] ;
                foreach (Valvula j in valvulas)j.Flujo=0;
                foreach (Salida j in salidas) j.Flujo = 0;
                return resultado;

            }
            else return "La configuracion no existe";
        }
    }
}
