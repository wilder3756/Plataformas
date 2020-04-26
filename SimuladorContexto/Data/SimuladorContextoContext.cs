using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimuladorContexto.Models;

namespace SimuladorContexto.Data
{
    public class SimuladorContextoContext : DbContext
    {
        public SimuladorContextoContext(DbContextOptions<SimuladorContextoContext> options)
            : base(options)
        {
        }

        public DbSet<Escenario> Escenario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Personaje> Situacion { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<Partida> Partida { get; set; }
    }
}
