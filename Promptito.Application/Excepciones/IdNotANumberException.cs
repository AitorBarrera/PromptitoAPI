using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.Excepciones
{
    public class IdNotANumberException : Exception
    {
        public IdNotANumberException()
        {
        }

        public IdNotANumberException(string? message) : base(message)
        {
        }

        public IdNotANumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
