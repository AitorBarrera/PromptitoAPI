using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{

    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        public UsuarioController(IPromptitoDbContext context)
        {
            _context = context;
        }

        [HttpGet("", Name = "GetUsuarios")]
        public async Task<ActionResult<List<Usuario>>> GetAllUsuarios()
        {
            return await _context.Usuarios
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
