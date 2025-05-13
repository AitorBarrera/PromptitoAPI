using Microsoft.Extensions.DependencyInjection;
using Promptito.Application.Interfaces;
using Promptito.Application.Servicios;
using System.Reflection;

namespace Promptito.Application
{
    //Inyeccion de dependencias para el projecto
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(configuration =>
            //{
            //    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //});

            services.AddScoped(typeof(IServicioCRUD<,,,>), typeof(ServicioCRUD<,,,>));
            services.AddScoped(typeof(IServicioFavoritos), typeof(ServicioFavoritos));

            return services;
        }

    }
}
