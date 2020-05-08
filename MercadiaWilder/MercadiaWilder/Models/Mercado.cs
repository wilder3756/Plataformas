using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MercadiaWilder.Models
{
    public class Mercado
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        public int PropietarioId { get; set; }
        public Propietario Propietario { get; set; }

        public string Estado { get; set; }
    }
}
