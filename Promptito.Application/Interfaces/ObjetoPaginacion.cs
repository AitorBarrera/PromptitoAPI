using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.Interfaces
{
    public class ObjetoPaginacion<TDatos>
        where TDatos : class
    {
        public List<TDatos>? Datos { get; set; }

        public int CantidadTotal { get; set; }

        public int Pagina { get; set; }

        public int CantidadPorPagina { get; set; }

        public int CantidadDePaginas { get; set; }

    }
}
