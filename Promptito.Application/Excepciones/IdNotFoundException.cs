using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.Excepciones
{
    public class IdNotFoundException : Exception
    {
        public IdNotFoundException()
        {
        }

        public IdNotFoundException(string? message) : base(message)
        {
        }

        public IdNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
