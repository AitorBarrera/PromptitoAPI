using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.DTO_Post;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Application.Servicios;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class UsuarioController : ControllerBase, IGenericController<Usuario, UsuarioDTO, UsuarioDTONavegacion, UsuarioDTOPost>
    {
        private readonly IServicioCRUD<Usuario, UsuarioDTO, UsuarioDTONavegacion, UsuarioDTOPost> _servicioCRUD;
        private readonly IServicioFavoritos _servicioFavoritos;
        private readonly IServicioNavegacionPorId _servicioNavegacionPorId;

        public UsuarioController(
            IServicioCRUD<Usuario, UsuarioDTO, UsuarioDTONavegacion, UsuarioDTOPost> servicioCRUD,
            IServicioFavoritos servicioFavoritos, 
            IServicioNavegacionPorId servicioNavegacionPorId)
        {
            _servicioCRUD = servicioCRUD;
            _servicioFavoritos = servicioFavoritos;
            _servicioNavegacionPorId = servicioNavegacionPorId;
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
            return await _servicioNavegacionPorId.GetByUsuarioId(id);
        }

        [HttpGet("[controller]/dto/{id}", Name = "GetUsuarioDTOById")]
        public async Task<ActionResult<UsuarioDTO>> GetByIdDTOController(int id)
        {
            return await _servicioCRUD.GetByIdDTO(id);
        }

        //[HttpGet("[controller]/dto/getByIdClerk/{id}", Name = "GetUsuarioDTOByIdClerk")]
        //public async Task<ActionResult<UsuarioDTO>> GetByIdClerkDTOController(int id)
        //{
        //    return  await _context.Set<TEntity>().FindAsync(id);
        //}

        [HttpPost("[controller]", Name = "PostUsuario")]
        public async Task<ActionResult<UsuarioDTO>> PostController(UsuarioDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
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

        [HttpPost("[controller]/addFavorite", Name = "AddFavorite")]
        public async Task<ActionResult<UsuarioDTONavegacion>> AddFavorite([FromQuery] int usuarioId, int promptId)
        {
            return await _servicioFavoritos.AddFavorite(usuarioId, promptId);
        }

        [HttpDelete("[controller]/RemoveFavorite", Name = "RemoveFavorite")]
        public async Task<ActionResult<string>> RemoveFavorite([FromQuery] int usuarioId, int promptId)
        {
            return await _servicioFavoritos.RemoveFavorite(usuarioId, promptId);
        }
    }
}
