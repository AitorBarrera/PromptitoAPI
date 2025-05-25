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
    public class ParametroController : ControllerBase, IGenericController<Parametro, ParametroDTO, ParametroDTONavegacion, ParametroDTOPost>
    {
        private readonly IServicioCRUD<Parametro, ParametroDTO, ParametroDTONavegacion, ParametroDTOPost> _servicioCRUD;
        private readonly IServicioNavegacionPorId _servicioNavegacionPorId;

        public ParametroController(IServicioCRUD<Parametro, ParametroDTO, ParametroDTONavegacion, ParametroDTOPost> servicioCRUD, IServicioNavegacionPorId servicioNavegacionPorId)
        {
            _servicioCRUD = servicioCRUD;
            _servicioNavegacionPorId = servicioNavegacionPorId;
        }
        [HttpGet("[controller]", Name = "GetAllParametro")]
        public async Task<ActionResult<List<ParametroDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/dto", Name = "GetAllDTOParametro")]
        public async Task<ActionResult<List<ParametroDTO>>> GetAllDTOController()
        {
            return await _servicioCRUD.GetAllDTO();
        }

        [HttpGet("[controller]/{id}", Name = "GetParametroById")]
        public async Task<ActionResult<ParametroDTONavegacion>> GetByIdController(int id)
        {
            return await _servicioNavegacionPorId.GetByParametroId(id);
        }

        [HttpGet("[controller]/dto/{id}", Name = "GetParametroDTOById")]
        public async Task<ActionResult<ParametroDTO>> GetByIdDTOController(int id)
        {
            return await _servicioCRUD.GetByIdDTO(id);
        }

        [HttpPost("[controller]", Name = "PostParametro")]
        public async Task<ActionResult<ParametroDTO>> PostController(ParametroDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
        }

        [HttpPut("[controller]", Name = "UpdateParametro")]
        public async Task<ActionResult<ParametroDTO>> UpdateController(ParametroDTO dto)
        {
            return await _servicioCRUD.Update(dto);
        }

        [HttpDelete("[controller]", Name = "DeleteParametro")]
        public async Task<ActionResult<string?>> DeleteController(int id)
        {
            return await _servicioCRUD.Delete(id);
        }
    }
}
