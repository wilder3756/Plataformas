using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorContexto.Models
{
    public class Partida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Variable1Acumulado { get; set; }
        public int Variable2Acumulado { get; set; }
        public int Variable3Acumulado { get; set; }

    }
}