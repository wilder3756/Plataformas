using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maraton1.Clases
{
    public class CalendarioHAAB
    {
        private int año;
        private string mes;
        private int dia;
        private static string[] listaMeses;


        public CalendarioHAAB(int año,string mes,int dia)
        {
            listaMeses = new string[19] { "pop", "no", "zip", "zotz", "tzec", "xul", "yoxkin", "mol", "chen", "yax", "zac", "ceh", "mac", "kankin", "muan", "pax", "koyab", "cumhu" ,"uayet"};
            if (año>=0 && año < 5000 && listaMeses.Contains(mes) && dia>=0 && dia<20)
            {
                this.año = año;
                this.mes = mes;
                if (mes.Equals("uayet") && dia>4)
                {
                    throw new Exception("el mes uayet solo tiene 5 dias(0-4)");
                }
                this.dia = dia;
            }
            else throw new Exception("No se cumplen los requsitos para crear el calendario");
        }

        public CalendarioTzolkin convertirTzolkin()
        {
            int nromes = 0, nroDia = 0, DiaT = 1,NombreT=0 , AñoT=this.año;
            for(int i = 0; i < listaMeses.Length; i++)
            {
                if (mes.Equals(listaMeses[i]))
                {
                    nromes = i + 1;
                }
                if (nromes < 19) nroDia = (nromes - 1) * 20 + dia+1;
                if (nromes == 19) nroDia = 18 * 20 + dia + 1;

                if (nroDia > 260) AñoT ++ ;

                while (nroDia > 0)
                {
                    if (DiaT == 13) DiaT = 1;
                    else if (DiaT < 13 ) DiaT++;
                    if (NombreT == 18) NombreT = 0;
                    else if (NombreT < 18) NombreT++;
                    nroDia--;
                }
            }
            return new CalendarioTzolkin(AñoT, CalendarioTzolkin.listaNombreDias[NombreT], DiaT);
        }
    }
}
