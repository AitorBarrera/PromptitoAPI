using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Promptito.Application;
using Promptito.Application.Interfaces;

namespace Promptito.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PromptitoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PromptitoDbConnection"))

                );

            services.AddScoped<IPromptitoDbContext>(provider =>
                provider.GetService<PromptitoDbContext>());

            return services;
        }
    }
}
