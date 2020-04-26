using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimuladorContexto.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public int PersonajeId { get; set; }
        public int SituacionId { get; set; }
        public int RespuestaId { get; set; }
        public int Respuesta2Id { get; set; }
        public Personaje Personaje { get; set; }
        public Situacion Situacion { get; set; }
        public Respuesta Respuesta { get; set; }
    }
}
