using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MercadiaWilder.Models;

namespace MercadiaWilder.Data
{
    public class mercadiaWilderContext: DbContext
    {
        public mercadiaWilderContext(DbContextOptions<mercadiaWilderContext> options)
            : base(options)
        {
        }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<UnidadResidencial> UnidadResidencial { get; set; }
        public DbSet<Apartamento> Apartamento { get; set; }
        public DbSet<Propietario> Propietario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Mercado> Mercado { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}
