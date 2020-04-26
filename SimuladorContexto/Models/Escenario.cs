using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorContexto.Models
{
    public class Escenario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Descripcion { get; set; }
        public int MetaVariable1 { get; set; }
        public int MetaVariable2 { get; set; }
        public int MetaVariable3 { get; set; }
        public Boolean Estado { get; set; }
        public ICollection<Rol> Roles { get; set; }
    }
}
