using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;
using Promptito.Persistance;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("prompts")]
    public class PromptController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        public PromptController(IPromptitoDbContext context)
        {
            _context = context;
        }

        [HttpGet("", Name = "GetPrompts")]
        public async Task<ActionResult<List<PromptDTO>>> GetAllPrompts()
        {
            return await _context.Prompts
                .Select(p => new PromptDTO
                {
                    Id = p.Id,
                    Titulo = p.Titulo,
                    Descripcion = p.Descripcion,
                    FechaCreacion = p.FechaCreacion,
                    UsuarioCreadorId = p.UsuarioCreadorId,
                    Llms = p.Llms.Select(l => new LlmDTO
                    {
                        Id = l.Id,
                        Nombre = l.Nombre,
                        Version = l.Version
                    }).ToList()
                })
                .ToListAsync();
        }

        [HttpGet("/{id}", Name = "GetPromptById")]
        public async Task<ActionResult<Prompt>> GetPromptById(int id)
        {
            return await _context.Prompts.FindAsync(id);
        }
    }
}
