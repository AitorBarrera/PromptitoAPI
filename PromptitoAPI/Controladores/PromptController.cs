using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain;

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
        public async Task<ActionResult<List<Prompt>>> GetAllPrompts()
        {
            return await _context.Prompts.ToListAsync();
        }

        [HttpGet("/{id}", Name = "GetPromptById")]
        public async Task<ActionResult<Prompt>> GetPromptById(int id)
        {
            return await _context.Prompts.FindAsync(id);
        }
    }
}
