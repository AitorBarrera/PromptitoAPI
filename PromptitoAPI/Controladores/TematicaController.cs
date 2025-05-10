using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("tematicas")]
    public class TematicaController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        public TematicaController(IPromptitoDbContext context)
        {
            _context = context;
        }

        [HttpGet("", Name = "GetTematicas")]
        public async Task<ActionResult<List<Tematica>>> GetAllTematicas()
        {
            return await _context.Tematicas
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetTematicaById")]
        public async Task<ActionResult<Tematica>> GetTematicaById(int id)
        {
            return await _context.Tematicas.FindAsync(id);
        }
    }
}
