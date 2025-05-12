using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.DTO_Post;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{

    [ApiController]
    [Route("")]
    public class UsuarioController : ControllerBase, IGenericController<Usuario, UsuarioDTO, UsuarioDTONavegacion, UsuarioDTOPost>
    {
        private readonly IServicioCRUD<Usuario, UsuarioDTO, UsuarioDTONavegacion, UsuarioDTOPost> _servicioCRUD;
        public readonly IPromptitoDbContext _context;
        public readonly IMapper _mapper;

        public UsuarioController(IServicioCRUD<Usuario, UsuarioDTO, UsuarioDTONavegacion, UsuarioDTOPost> servicioCRUD, IPromptitoDbContext context, IMapper mapper)
        {
            _servicioCRUD = servicioCRUD;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("[controller]", Name = "GetAllUsuario")]
        public async Task<ActionResult<List<UsuarioDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/dto", Name = "GetAllDTOUsuario")]
        public async Task<ActionResult<List<UsuarioDTO>>> GetAllDTOController()
        {
            return await _servicioCRUD.GetAllDTO();
        }

        [HttpGet("[controller]/{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<UsuarioDTONavegacion>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpGet("[controller]/dto/{id}", Name = "GetUsuarioDTOById")]
        public async Task<ActionResult<UsuarioDTO>> GetByIdDTOController(int id)
        {
            return await _servicioCRUD.GetByIdDTO(id);
        }

        [HttpPost("[controller]", Name = "PostUsuario")]
        public async Task<ActionResult<UsuarioDTO>> PostController(UsuarioDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
        }

        [HttpPost("[controller]/addFavorite", Name = "AddFavorite")]
        public async Task<ActionResult<UsuarioDTONavegacion>> AddFavorite([FromQuery] int usuarioId, int promptId)
        {
            Usuario? usuario = await _context.Usuarios.FindAsync(usuarioId);
            Prompt? promptToAdd = await _context.Prompts.FindAsync(promptId);

            if (promptToAdd == null || usuario == null)
            {
                return NotFound($"Prompt with ID {promptId} not found.");
            }

            usuario.PromptsFavoritos.Add(promptToAdd);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioDTONavegacion>(usuario);
        }

        [HttpDelete("[controller]/RemoveFavorite", Name = "RemoveFavorite")]
        public async Task<ActionResult<string>> RemoveFavorite([FromQuery] int usuarioId, int promptId)
        {
            Usuario? usuario = await _context.Usuarios.FindAsync(usuarioId);
            Prompt? promptToRemove = usuario.PromptsFavoritos.FirstOrDefault(p => p.Id == promptId);

            if (promptToRemove == null)
                return NotFound($"Prompt con ID {promptId} no encontrado.");

            if (usuario == null)
                return NotFound($"Usuario con ID {usuarioId} no encontrado.");


            usuario.PromptsFavoritos.Remove(promptToRemove);
            await _context.SaveChangesAsync();

            return Ok($"Prompt '{promptToRemove.Titulo}' borrado de favoritos del usuario '{usuario.Nombre}'.");
        }

        [HttpPut("[controller]", Name = "UpdateUsuario")]
        public async Task<ActionResult<UsuarioDTO>> UpdateController(UsuarioDTO dto)
        {
            return await _servicioCRUD.Update(dto);
        }

        [HttpDelete("[controller]", Name = "DeleteUsuario")]
        public async Task<ActionResult<string?>> DeleteController(int id)
        {
            return await _servicioCRUD.Delete(id);
        }
    }
}
