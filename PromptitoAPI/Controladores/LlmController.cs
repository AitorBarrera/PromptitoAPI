using Microsoft.AspNetCore.Mvc;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("llms")]
    public class LlmController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        public LlmController(IPromptitoDbContext context)
        {
            _context = context;
        }

        [HttpGet("", Name = "GetLlms")]
        public async Task<ActionResult<List<Llm>>> GetAllLlms()
        {
            return await _context.Llms
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetLlmById")]
        public async Task<ActionResult<Llm>> GetLlmById(int id)
        {
            return await _context.Llms.FindAsync(id);
        }
    }
}
