using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class PromptVarianteController : ControllerBase, IGenericController<PromptVariante, PromptVarianteDTO>
    {
        private readonly IServicioCRUD<PromptVariante, PromptVarianteDTO> _servicioCRUD;

        public PromptVarianteController(IServicioCRUD<PromptVariante, PromptVarianteDTO> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }


        [HttpGet("[controller]", Name = "GetAllPromptVariante")]
        public async Task<ActionResult<List<PromptVariante>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }


        [HttpGet("[controller]/{id}", Name = "GetPromptVarianteById")]
        public async Task<ActionResult<PromptVariante>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpPost("[controller]", Name = "PostPromptVariante")]
        public async Task<ActionResult<PromptVarianteDTO>> PostController(PromptVarianteDTO dto)
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
