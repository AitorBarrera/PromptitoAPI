using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{

    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        private readonly IMapper _mapper;
        public UsuarioController(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("", Name = "GetUsuarios")]
        public async Task<ActionResult<List<UsuarioDTO>>> GetAllUsuarios()
        {
            return await _context.Usuarios
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
    }
}
