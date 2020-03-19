using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2.Clases
{
    class Salida
    {
        private string nombre;
        private double flujo;

        public Salida()
        {
        }

        public Salida(string nombre, double flujo)
        {
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.flujo = flujo;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Flujo { get => flujo; set => flujo = value; }
    }
}
