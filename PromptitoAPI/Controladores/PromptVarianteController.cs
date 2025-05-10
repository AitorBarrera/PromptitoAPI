using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("promptVariantes")]
    public class PromptVarianteController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        public PromptVarianteController(IPromptitoDbContext context)
        {
            _context = context;
        }

        [HttpGet("", Name = "GetPromptVariantes")]
        public async Task<ActionResult<List<PromptVariante>>> GetAllPromptVariantes()
        {
            return await _context.PromptVariantes
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetPromptVarianteById")]
        public async Task<ActionResult<PromptVariante>> GetPromptVarianteById(int id)
        {
            return await _context.PromptVariantes.FindAsync(id);
        }
    }
}
