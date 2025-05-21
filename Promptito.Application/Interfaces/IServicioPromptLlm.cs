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
    public interface IServicioPromptLlm
    {

        Task<ActionResult<PromptDTONavegacion>> AddLlmToPrompt(int promptId, int llmId);

        Task<ActionResult<string>> RemoveLlmFromPrompt( int promptId, int llmId);
    }
}
