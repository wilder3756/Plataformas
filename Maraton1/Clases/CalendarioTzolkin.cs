using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton1.Clases
{
    public class CalendarioTzolkin
    {
        private int año;
        //private int periodo;
        private string diaNombre;
        private int diaNumero;
        public static string[] listaNombreDias = new string[20] { "imix", "ik", "akbal", "kan", "chicchan", "cimi", "manik", "lamat", "muluk", "ok", "chuen", "eb", "ben", "ix", "mem", "cib", "caban", "eznab", "canac", "ahau" };;
        public int Año { get => año; set => año = value; }
        public string DiaNombre { get => diaNombre; set => diaNombre = value; }
        public int DiaNumero { get => diaNumero; set => diaNumero = value; }

        public CalendarioTzolkin(int año, string diaNombre, int diaNumero)
        {

            if (año >= 0 && año < 5000 && listaNombreDias.Contains(diaNombre) && diaNumero > 0 && diaNumero < 14)
            {
                this.año = año;
                this.diaNombre = diaNombre;
                this.diaNumero = diaNumero;
            }
            else throw new Exception("No se cumplen los requsitos para crear el calendario");
           
        }
    }
}
