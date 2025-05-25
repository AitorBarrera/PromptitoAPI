
using Promptito.Application.Excepciones;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Promptito.API.Middlewares
{
    public class ExcepcionesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExcepcionesMiddleware> _logger;

        public ExcepcionesMiddleware(RequestDelegate next, ILogger<ExcepcionesMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/problem+json";

            var statusCode = exception switch
            {
                ApiException apiEx => apiEx.StatusCode,
                ValidationException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => 404,
                _ => StatusCodes.Status500InternalServerError
            };

            var problemDetails = new ProblemDetails
            {
                Type = GetProblemTypeUri(statusCode),
                Title = exception is ApiException ? exception.Message : "An error occurred",
                Status = statusCode,
                Instance = context.Request.Path
            };

            if (exception is ApiException apiException && apiException.ErrorCode != null)
            {
                problemDetails.Extensions.Add("errorCode", apiException.ErrorCode);
            }

            if (context.RequestServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
            {
                problemDetails.Extensions.Add("stackTrace", exception.StackTrace);
            }

            await context.Response.WriteAsJsonAsync(problemDetails);
        }

        private static string GetProblemTypeUri(int statusCode) => statusCode switch
        {
            400 => "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            404 => "https://tools.ietf.org/html/rfc9110#section-15.5.5",
            500 => "https://tools.ietf.org/html/rfc9110#section-15.6.1",
            _ => "https://tools.ietf.org/html/rfc9110#section-15.5.1"
        };
    }
}
