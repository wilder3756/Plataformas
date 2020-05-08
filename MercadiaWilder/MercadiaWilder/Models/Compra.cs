using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadiaWilder.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int MercadoId { get; set; }
        public Mercado Mercado { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
