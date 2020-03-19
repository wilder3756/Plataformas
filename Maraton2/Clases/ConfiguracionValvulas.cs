using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2.Clases
{
    class ConfiguracionValvulas
    {
        public static bool derecha = true;
        public static bool izquierda = false;

        private bool[] configuracionValculas;

        public ConfiguracionValvulas()
        {
        }

        public ConfiguracionValvulas(string configuracion)
        {
            string[] aux = configuracion.Split(' ');
            configuracionValculas = new bool[aux.Length];
            for(int i = 0; i < aux.Length; i++)
            {
                if(aux[i].com)
            }
            
        }
    }
}
