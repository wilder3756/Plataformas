using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2.Clases
{
    
    class Valvula
    {
        public static bool derecha = true;
        public static bool izquierda = false;
        private string nombre;
        private bool configuracion;
        private double flujo;

        public Valvula()
        {
        }

        public Valvula(string nombre, bool configuracion, double flujo)
        {
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Configuracion = configuracion;
            this.Flujo = flujo;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public bool Configuracion { get => configuracion; set => configuracion = value; }
        public double Flujo { get => flujo; set => flujo = value; }
    }
}
