using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton2.Clases
{
    class Entrada
    {
        private string nombre;
        private double flujo;
        private string nombreValvulaSalida;

        public Entrada()
        {
        }

        public Entrada(string nombre, double flujo, string nombreValvulaSalida)
        {
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.flujo = flujo;
            this.nombreValvulaSalida = nombreValvulaSalida ?? throw new ArgumentNullException(nameof(nombreValvulaSalida));
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Flujo { get => flujo; set => flujo = value; }
        public string NombreValvulaSalida { get => nombreValvulaSalida; set => nombreValvulaSalida = value; }
    }
}
