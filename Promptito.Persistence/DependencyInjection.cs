using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promptito.Application.Interfaces;
using Promptito.Persistance;

namespace Cartas.Persistence
{
    public static class DependencyInjection
    {
        //Añadir el contexto de la base de datos al projecto y conectar con la conexion definida en la configuracion del projecto
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PromptitoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PromptitoDbConnection")));

            services.AddScoped<IPromptitoDbContext>(provider => 
                provider.GetService<PromptitoDbContext>());

            return services;
        }

    }
}
