using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2.Clases
{
    public class ConfiguracionValvulas
    {
        public static bool derecha = true;
        public static bool izquierda = false;

        private bool[] configuracionValvulas;

        public ConfiguracionValvulas()
        {
        }

        public ConfiguracionValvulas(string configuracion)
        {
            configuracion = configuracion.ToUpper();
            string[] aux = configuracion.Split(' ');
            configuracionValvulas = new bool[aux.Length];
            
            for (int i = 0; i < aux.Length; i++)
            {
                
                if (aux[i].CompareTo("L") == 0) configuracionValvulas[i] = izquierda;
                else if (aux[i].CompareTo("R") == 0) configuracionValvulas[i] = derecha;
                else throw new Exception("las configuraciones de la valvulas no son validas");
            }
            

        }

        public bool[] ConfiguracionValculas { get => configuracionValvulas; set => configuracionValvulas = value; }

        public string imprimir()
        {
            string salida = "";
            foreach(bool i in configuracionValvulas)
            {
                if (i == derecha) salida += "R";
                else salida += "L";
            }
            return salida;
        }
    }
}
