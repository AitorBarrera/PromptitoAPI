
using Microsoft.AspNetCore.Mvc;
using Promptito.Application.DTO_PostConNavegacion;

namespace Promptito.Application.Interfaces
{
    public interface IServicioPostConNavegacion
    {
        Task<ActionResult<string>> AddPromptConNavegacion(PromptDTOPostConNavegacion promptConNavegacion);

    }
}
