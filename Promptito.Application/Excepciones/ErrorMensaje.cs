using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.Excepciones;

public class ErrorMensaje
{
    public int? StatusCode { get; set; }
    public string? Mensaje { get; set; }

    public ErrorMensaje()
    {
    }

    public ErrorMensaje(int statusCode, string mensaje)
    {
        StatusCode = statusCode;
        Mensaje = mensaje;
    }

}
