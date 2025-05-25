using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Interfaces
{
    public interface IServicioUsuario
    {
        Task<ActionResult<UsuarioDTO>> GetByIdClerkDTOController(string idClerk);           
    }
}
