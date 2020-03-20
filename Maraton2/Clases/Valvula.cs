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
        private string confDerecha;
        private string confIzquierda;
        private double flujo;

        public Valvula()
        {
        }

        public Valvula(string nombre, string confDerecha, string confIzquierda)
        {
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Configuracion = configuracion;
            this.Flujo = 0;
            this.confDerecha= confDerecha;
            this.confIzquierda= confIzquierda;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public bool Configuracion { get => configuracion; set => configuracion = value; }
        public double Flujo { get => flujo; set => flujo = value; }
        public string ConfDerecha { get => confDerecha; set => confDerecha = value; }
        public string ConfIzquierda { get => confIzquierda; set => confIzquierda = value; }
    }
}
