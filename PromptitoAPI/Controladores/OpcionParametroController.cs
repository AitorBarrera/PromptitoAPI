using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("opcionParametros")]
    public class OpcionParametroController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        public OpcionParametroController(IPromptitoDbContext context)
        {
            _context = context;
        }

        [HttpGet("", Name = "GetOpcionParametros")]
        public async Task<ActionResult<List<OpcionParametro>>> GetAllOpcionParametros()
        {
            return await _context.OpcionParametros
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetOpcionParametroById")]
        public async Task<ActionResult<OpcionParametro>> GetOpcionParametroById(int id)
        {
            return await _context.OpcionParametros.FindAsync(id);
        }
    }
}
