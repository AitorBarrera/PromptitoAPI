using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promptito.Application.DTO;
using Promptito.Application.NavegacionDTO;

namespace Promptito.Application.Interfaces
{
    public interface IServicioPaginacion
    {
        Task<ActionResult<ObjetoPaginacion<PromptDTONavegacion>>> GetAllPromptsPagination(int pagina = 1, int cantidadPorPagina = 10);

        Task<ActionResult<ObjetoPaginacion<PromptDTO>>> GetAllPromptsDTOPagination( int pagina = 1, int cantidadPorPagina = 10);
    }
}
