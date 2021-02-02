using System;

namespace DomainCore.Data.Entities
{
    public class Solicitud
    {
        public int Id { get; set; }
        public Personas Persona { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Solicitud()
        {
            FechaCreacion = DateTime.UtcNow;
        }
    }
}
