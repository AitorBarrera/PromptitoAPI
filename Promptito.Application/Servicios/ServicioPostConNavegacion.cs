using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Promptito.Application.DTO;
using Promptito.Application.DTO_PostConNavegacion;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Servicios
{
    public class ServicioPostConNavegacion : IServicioPostConNavegacion
    {
        private readonly IPromptitoDbContext _context;
        private readonly IMapper _mapper;

        public ServicioPostConNavegacion(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ActionResult<string>> AddPromptConNavegacion(PromptDTOPostConNavegacion promptConNavegacion) {

            Prompt prompt = _mapper.Map<Prompt>(promptConNavegacion);

            if (promptConNavegacion.LlmIds != null && promptConNavegacion.LlmIds.Any())
            {
                List<Llm> promptLlms = _context.Llms
                    .Where(l => promptConNavegacion.LlmIds.Contains(l.Id))
                    .ToList();

                foreach (Llm llm in promptLlms)
                {
                    prompt.Llms.Add(llm);
                }
            }

            if (promptConNavegacion.TematicaIds != null && promptConNavegacion.TematicaIds.Any())
            {
                List<Tematica> promptTematicas = _context.Tematicas
                    .Where(t => promptConNavegacion.TematicaIds.Contains(t.Id))
                    .ToList();

                foreach (Tematica tematica in promptTematicas)
                {
                    prompt.Tematicas.Add(tematica);
                }
            }

            _context.Prompts.Add(prompt);
            await _context.SaveChangesAsync();

            return "Prompt agregado";
        }
    }
}
