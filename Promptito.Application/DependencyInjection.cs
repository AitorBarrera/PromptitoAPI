using Microsoft.Extensions.DependencyInjection;
using Promptito.Application.Interfaces;
using Promptito.Application.Servicios;
using System.Reflection;

namespace Cartas.Application
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

            services.AddScoped(typeof(IServicioCRUD<,>), typeof(ServicioCRUD<,>));

            return services;
        }

    }
}
