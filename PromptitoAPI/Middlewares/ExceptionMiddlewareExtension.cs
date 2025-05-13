using Promptito.API.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.Servicios
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExcepciones(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExcepcionesMiddleware>();
        }
    }
}
