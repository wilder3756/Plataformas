using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadiaWilder.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int contenido { get; set; }
        public string UnidadMedida { get; set; }

        public Boolean Estado { get; set; }
    }
}
