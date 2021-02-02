using Microsoft.EntityFrameworkCore;
using DomainCore.Data.Entities;

namespace DomainCore.Data.Context
{
    public class AppDbContext :DbContext
    {
        #region Construct

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #endregion

        #region DbSet's

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Solicitud> Solicitud { get; set; }
        public DbSet<Estado> Estado { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relations
            modelBuilder.Entity<Solicitud>().HasOne<Estado>(s => s.Estado);
            modelBuilder.Entity<Solicitud>().HasOne<Personas>(s => s.Persona);

            // personas properties config
            modelBuilder.Entity<Personas>().Property(s => s.Id).HasDefaultValue(0).IsRequired();
            modelBuilder.Entity<Personas>().Property(s => s.Nombre).IsRequired();
            modelBuilder.Entity<Personas>().Property(s => s.Apellido).IsRequired();
            modelBuilder.Entity<Personas>().Property(s => s.FechaNacimiento).IsRequired();
            modelBuilder.Entity<Personas>().Property(s => s.Pasaporte).IsRequired();
            modelBuilder.Entity<Personas>().Property(s => s.Direccion).IsRequired();
            modelBuilder.Entity<Personas>().Property(s => s.Sexo).IsRequired();

            // solicitudes properties config
            modelBuilder.Entity<Solicitud>().Property(s => s.Id).HasDefaultValue(0).IsRequired(); 
            // estados properties config
            modelBuilder.Entity<Estado>().Property(s => s.Id).HasDefaultValue(0).IsRequired();
        }

        #endregion
    }
}
