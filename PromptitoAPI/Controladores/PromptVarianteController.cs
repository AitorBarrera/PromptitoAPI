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
    public class PromptVarianteController : ControllerBase, IGenericController<PromptVariante, PromptVarianteDTO, PromptVarianteDTONavegacion, PromptVarianteDTOPost>
    {
        private readonly IServicioCRUD<PromptVariante, PromptVarianteDTO, PromptVarianteDTONavegacion, PromptVarianteDTOPost> _servicioCRUD;
        private readonly IServicioNavegacionPorId _servicioNavegacionPorId;

        public PromptVarianteController(IServicioCRUD<PromptVariante, PromptVarianteDTO, PromptVarianteDTONavegacion, PromptVarianteDTOPost> servicioCRUD, IServicioNavegacionPorId servicioNavegacionPorId)
        {
            _servicioCRUD = servicioCRUD;
            _servicioNavegacionPorId = servicioNavegacionPorId;
        }

        [HttpGet("[controller]", Name = "GetAllPromptVariante")]
        public async Task<ActionResult<List<PromptVarianteDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/dto", Name = "GetAllDTOPromptVariante")]
        public async Task<ActionResult<List<PromptVarianteDTO>>> GetAllDTOController()
        {
            return await _servicioCRUD.GetAllDTO();
        }

        [HttpGet("[controller]/{id}", Name = "GetPromptVarianteById")]
        public async Task<ActionResult<PromptVarianteDTONavegacion>> GetByIdController(int id)
        {
            return await _servicioNavegacionPorId.GetByPromptVarianteId(id);
        }

        [HttpGet("[controller]/dto/{id}", Name = "GetPromptVarianteDTOById")]
        public async Task<ActionResult<PromptVarianteDTO>> GetByIdDTOController(int id)
        {
            return await _servicioCRUD.GetByIdDTO(id);
        }

        [HttpPost("[controller]", Name = "PostPromptVariante")]
        public async Task<ActionResult<PromptVarianteDTO>> PostController(PromptVarianteDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
        }

        [HttpPut("[controller]", Name = "UpdatePromptVariante")]
        public async Task<ActionResult<PromptVarianteDTO>> UpdateController(PromptVarianteDTO dto)
        {
            return await _servicioCRUD.Update(dto);
        }

        [HttpDelete("[controller]", Name = "DeletePromptVariante")]
        public async Task<ActionResult<string?>> DeleteController(int id)
        {
            return await _servicioCRUD.Delete(id);
        }
    }
}
