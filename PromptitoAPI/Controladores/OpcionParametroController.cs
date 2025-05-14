using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO_Post;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Application.Servicios;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class OpcionParametroController : ControllerBase, IGenericController<OpcionParametro, OpcionParametroDTO, OpcionParametroDTONavegacion, OpcionParametroDTOPost>
    {
        private readonly IServicioCRUD<OpcionParametro, OpcionParametroDTO, OpcionParametroDTONavegacion, OpcionParametroDTOPost> _servicioCRUD;
        private readonly IServicioNavegacionPorId _servicioNavegacionPorId;

        public OpcionParametroController(IServicioCRUD<OpcionParametro, OpcionParametroDTO, OpcionParametroDTONavegacion, OpcionParametroDTOPost> servicioCRUD, IServicioNavegacionPorId servicioNavegacionPorId)
        {
            _servicioCRUD = servicioCRUD;
            _servicioNavegacionPorId = servicioNavegacionPorId;
        }
        [HttpGet("[controller]", Name = "GetAllOpcionParametro")]
        public async Task<ActionResult<List<OpcionParametroDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/dto", Name = "GetAllDTOOpcionParametro")]
        public async Task<ActionResult<List<OpcionParametroDTO>>> GetAllDTOController()
        {
            return await _servicioCRUD.GetAllDTO();
        }

        [HttpGet("[controller]/{id}", Name = "GetOpcionParametroById")]
        public async Task<ActionResult<OpcionParametroDTONavegacion>> GetByIdController(int id)
        {
            return await _servicioNavegacionPorId.GetByOpcionParametroId(id);
        }

        [HttpGet("[controller]/dto/{id}", Name = "GetOpcionParametroDTOById")]
        public async Task<ActionResult<OpcionParametroDTO>> GetByIdDTOController(int id)
        {
            return await _servicioCRUD.GetByIdDTO(id);
        }

        [HttpPost("[controller]", Name = "PostOpcionParametro")]
        public async Task<ActionResult<OpcionParametroDTO>> PostController(OpcionParametroDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
        }

        [HttpPut("[controller]", Name = "UpdateOpcionParametro")]
        public async Task<ActionResult<OpcionParametroDTO>> UpdateController(OpcionParametroDTO dto)
        {
            return await _servicioCRUD.Update(dto);
        }

        [HttpDelete("[controller]", Name = "DeleteOpcionParametro")]
        public async Task<ActionResult<string?>> DeleteController(int id)
        {
            return await _servicioCRUD.Delete(id);
        }
    }
}
