using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Excepciones;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Interfaces
{
    public interface IServicioPromptTematica
    {

        Task<ActionResult<PromptDTONavegacion>> AddTematicaToPrompt(int promptId, int tematicaId);

        Task<ActionResult<string>> RemoveTematicaFromPrompt(int promptId, int tematicaId);
    }
}
