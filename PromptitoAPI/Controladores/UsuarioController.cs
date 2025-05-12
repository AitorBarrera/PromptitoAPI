using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{

    [ApiController]
    [Route("")]
    public class UsuarioController : ControllerBase, IGenericController<Usuario, UsuarioDTO>
    {
        private readonly IServicioCRUD<Usuario, UsuarioDTO> _servicioCRUD;

        public UsuarioController(IServicioCRUD<Usuario, UsuarioDTO> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }


        [HttpGet("[controller]", Name = "GetAllUsuario")]
        public async Task<ActionResult<List<Usuario>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }


        [HttpGet("[controller]/{id}", Name = "GetUsuarioById")]
        public async Task<ActionResult<Usuario>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpPost("[controller]", Name = "PostUsuario")]
        public async Task<ActionResult<UsuarioDTO>> PostController(UsuarioDTO dto)
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
    }
}
