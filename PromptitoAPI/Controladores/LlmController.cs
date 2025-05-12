using Microsoft.AspNetCore.Mvc;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO_Post;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class LlmController : ControllerBase, IGenericController<Llm, LlmDTO, LlmDTONavegacion, LlmDTOPost>
    {
        private readonly IServicioCRUD<Llm, LlmDTO, LlmDTONavegacion, LlmDTOPost> _servicioCRUD;

        public LlmController(IServicioCRUD<Llm, LlmDTO, LlmDTONavegacion, LlmDTOPost> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }

        [HttpGet("[controller]", Name = "GetAllLlm")]
        public async Task<ActionResult<List<LlmDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/{id}", Name = "GetLlmById")]
        public async Task<ActionResult<LlmDTONavegacion>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpPost("[controller]", Name = "PostLlm")]
        public async Task<ActionResult<LlmDTO>> PostController(LlmDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
        }

        [HttpPut("[controller]", Name = "UpdateLlm")]
        public async Task<ActionResult<LlmDTO>> UpdateController(LlmDTO dto)
        {
            return await _servicioCRUD.Update(dto);
        }

        [HttpDelete("[controller]", Name = "DeleteLlm")]
        public async Task<ActionResult<string?>> DeleteController(int id)
        {
            return await _servicioCRUD.Delete(id);
        }
    }
}
