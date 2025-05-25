using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Interfaces
{
    public interface IServicioFavoritos
    {
        Task<ActionResult<UsuarioDTONavegacion>> AddFavorite([FromQuery] int usuarioId, int promptId);

        Task<ActionResult<string>> RemoveFavorite([FromQuery] int usuarioId, int promptId);
    }
}
