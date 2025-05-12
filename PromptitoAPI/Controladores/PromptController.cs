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
    public class PromptController : ControllerBase, IGenericController<Prompt, PromptDTO, PromptDTONavegacion, PromptDTOPost>
    {
        private readonly IServicioCRUD<Prompt, PromptDTO, PromptDTONavegacion, PromptDTOPost> _servicioCRUD;

        public PromptController(IServicioCRUD<Prompt, PromptDTO, PromptDTONavegacion, PromptDTOPost> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }

        [HttpGet("[controller]", Name = "GetAllPrompt")]
        public async Task<ActionResult<List<PromptDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/dto", Name = "GetAllDTOPrompt")]
        public async Task<ActionResult<List<PromptDTO>>> GetAllDTOController()
        {
            return await _servicioCRUD.GetAllDTO();
        }

        [HttpGet("[controller]/{id}", Name = "GetPromptById")]
        public async Task<ActionResult<PromptDTONavegacion>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpGet("[controller]/dto/{id}", Name = "GetPromptDTOById")]
        public async Task<ActionResult<PromptDTO>> GetByIdDTOController(int id)
        {
            return await _servicioCRUD.GetByIdDTO(id);
        }

        [HttpPost("[controller]", Name = "PostPrompt")]
        public async Task<ActionResult<PromptDTO>> PostController(PromptDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
        }

        [HttpPut("[controller]", Name = "UpdatePrompt")]
        public async Task<ActionResult<PromptDTO>> UpdateController(PromptDTO dto)
        {
            return await _servicioCRUD.Update(dto);
        }

        [HttpDelete("[controller]", Name = "DeletePrompt")]
        public async Task<ActionResult<string?>> DeleteController(int id)
        {
            return await _servicioCRUD.Delete(id);
        }
    }
}
