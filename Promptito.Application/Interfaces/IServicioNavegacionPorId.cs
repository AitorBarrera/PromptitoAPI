using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Excepciones;
using Promptito.Application.NavegacionDTO;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Interfaces
{
    public interface IServicioNavegacionPorId
    {
        Task<ActionResult<LlmDTONavegacion?>> GetByLlmId(int id);

        Task<ActionResult<OpcionParametroDTONavegacion?>> GetByOpcionParametroId(int id);
        Task<ActionResult<ParametroDTONavegacion?>> GetByParametroId(int id);
        Task<ActionResult<PromptDTONavegacion?>> GetByPromptId(int id);

        Task<ActionResult<PromptVarianteDTONavegacion?>> GetByPromptVarianteId(int id);
        Task<ActionResult<TematicaDTONavegacion?>> GetByTematicaId(int id);
        Task<ActionResult<UsuarioDTONavegacion?>> GetByUsuarioId(int id);
    }
}
