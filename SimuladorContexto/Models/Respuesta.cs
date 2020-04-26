using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorContexto.Models
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public Boolean Estado { get; set; }
        public int ProporcionVariable1 { get; set; }
        public int ProporcionVariable2 { get; set; }
        public int ProporcionVariable3 { get; set; }
        public int SituacionId { get; set; }
        public Situacion Situacion { get; set; }
        public ICollection<Tarjeta> Tarjetas { get; set; }
    }
}
