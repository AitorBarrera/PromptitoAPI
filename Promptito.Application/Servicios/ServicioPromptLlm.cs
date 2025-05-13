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
    public class ServicioPromptLlm : IServicioPromptLlm
    {
        protected readonly IPromptitoDbContext _context;
        protected readonly IMapper _mapper;

        public ServicioPromptLlm(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public async Task<ActionResult<PromptDTONavegacion>> AddLlmToPrompt([FromQuery] int promptId, int llmId)
        {
            Prompt? prompt = await _context.Prompts.Where(p => p.Id == promptId).Include(p => p.Llms).Select(p => p).SingleOrDefaultAsync();

            if (prompt == null)
                throw new ApiException($"Prompt con ID {promptId} no encontrado", 404, "prompt.not_found");


            Llm? llmToAdd = await _context.Llms.FindAsync(llmId);

            if (llmToAdd == null)
                throw new ApiException($"Llm con ID {llmId} no encontrado.", 404, "llm.not_found");

            if (prompt.Llms.Contains(llmToAdd))
                throw new ApiException("Este llm ya esta agregado al prompt.", 400, "promptllm.duplicated");

            prompt.Llms.Add(llmToAdd);
            await _context.SaveChangesAsync();

            return _mapper.Map<PromptDTONavegacion>(prompt);
        }

        public async Task<ActionResult<string>> RemoveLlmFromPrompt([FromQuery] int promptId, int llmId)
        {
            Prompt? prompt = await _context.Prompts.Where(p => p.Id == promptId).Include(p => p.Llms).Select(p => p).SingleOrDefaultAsync();

            if (prompt == null)
                throw new ApiException($"Prompt con ID {promptId} no encontrado", 404, "prompt.not_found");


            Llm? llmToRemove = await _context.Llms.FindAsync(llmId);

            if (llmToRemove == null)
                throw new ApiException($"Llm con ID {llmId} no encontrado.", 404, "promptfavorito.not_found");


            if (!prompt.Llms.Remove(llmToRemove)) throw new ApiException($"Llm con ID {promptId} no encontrada en el prompt indicado", 404, "LlmPrompt.not_found");
            await _context.SaveChangesAsync();

            return $"Llm '{llmToRemove.Nombre}' borrado de la lista de llms del prompt: '{prompt.Titulo}'.";
        }
    }
}
