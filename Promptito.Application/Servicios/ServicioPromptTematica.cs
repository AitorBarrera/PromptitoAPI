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

namespace Promptito.Application.Servicios
{
    public class ServicioPromptTematica : IServicioPromptTematica
    {
        protected readonly IPromptitoDbContext _context;
        protected readonly IMapper _mapper;

        public ServicioPromptTematica(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public async Task<ActionResult<PromptDTONavegacion>> AddTematicaToPrompt([FromQuery] int promptId, int TematicaId)
        {
            Prompt? prompt = await _context.Prompts.Where(p => p.Id == promptId).Include(p => p.Tematicas).Select(p => p).SingleOrDefaultAsync();

            if (prompt == null)
                throw new ApiException($"Prompt con ID {promptId} no encontrado", 404, "prompt.not_found");


            Tematica? TematicaToAdd = await _context.Tematicas.FindAsync(TematicaId);

            if (TematicaToAdd == null)
                throw new ApiException($"Tematica con ID {TematicaId} no encontrado.", 404, "tematica.not_found");

            if (prompt.Tematicas.Contains(TematicaToAdd))
                throw new ApiException("Esta tematica ya esta agregada al prompt.", 400, "tematicaPrompt.duplicated");

            prompt.Tematicas.Add(TematicaToAdd);
            await _context.SaveChangesAsync();

            return _mapper.Map<PromptDTONavegacion>(prompt);
        }

        public async Task<ActionResult<string>> RemoveTematicaFromPrompt([FromQuery] int promptId, int TematicaId)
        {
            Prompt? prompt = await _context.Prompts.Where(p => p.Id == promptId).Include(p => p.Tematicas).Select(p => p).SingleOrDefaultAsync();

            if (prompt == null)
                throw new ApiException($"Prompt con ID {promptId} no encontrado", 404, "prompt.not_found");


            Tematica? TematicaToRemove = await _context.Tematicas.FindAsync(TematicaId);

            if (TematicaToRemove == null)
                throw new ApiException($"Tematica con ID {TematicaId} no encontrado.", 404, "tematica.not_found");


            if (!prompt.Tematicas.Remove(TematicaToRemove)) throw new ApiException($"Tematica con ID {TematicaId} no encontrada en el prompt indicado", 404, "tematicaPrompt.not_found");
            await _context.SaveChangesAsync();

            return $"Tematica '{TematicaToRemove.Nombre}' borrado de la lista de Tematicas del prompt: '{prompt.Titulo}'.";
        }
    }
}
