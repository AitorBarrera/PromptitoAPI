using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("parametros")]
    public class ParametroController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        public ParametroController(IPromptitoDbContext context)
        {
            _context = context;
        }

        [HttpGet("", Name = "GetParametros")]
        public async Task<ActionResult<List<Parametro>>> GetAllParametros()
        {
            return await _context.Parametros
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetParametroById")]
        public async Task<ActionResult<Parametro>> GetParametroById(int id)
        {
            return await _context.Parametros.FindAsync(id);
        }
    }
}
