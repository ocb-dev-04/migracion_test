using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DomainCore.Data.Context;

namespace DomainCore.Config
{
    public static class ConfigAllServices
    {
        #region DbConnect

        public static void AddDbServices(
            this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseInMemoryDatabase("TestDB"));
        }

        #endregion

        #region All DI

        //  add all dependecies inyeccion
        public static void AddDI(this IServiceCollection services)
        {
            services.AddScoped<Core.Interfaces.IPersonasRep, Core.Repositories.PersonasRep>();
            services.AddScoped<Core.Interfaces.ISolicitudesRep, Core.Repositories.SolicitudesRep>();
            services.AddScoped<Core.Interfaces.IEstadosRep, Core.Repositories.EstadosRep>();

        }

        #endregion
    }
}
