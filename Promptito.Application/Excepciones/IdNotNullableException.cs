using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.Excepciones
{
    public class IdNotNullableException : Exception
    {
        public IdNotNullableException()
        {
        }

        public IdNotNullableException(string? message) : base(message)
        {
        }

        public IdNotNullableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
