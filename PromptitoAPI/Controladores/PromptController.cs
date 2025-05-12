using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.DTO_Post;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class PromptController : ControllerBase, IGenericController<Prompt, PromptDTO>
    {
        private readonly IServicioCRUD<Prompt, PromptDTO> _servicioCRUD;

        public PromptController(IServicioCRUD<Prompt, PromptDTO> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }


        [HttpGet("[controller]", Name = "GetAllPrompt")]
        public async Task<ActionResult<List<Prompt>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }


        [HttpGet("[controller]/{id}", Name = "GetPromptById")]
        public async Task<ActionResult<Prompt>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpPost("[controller]", Name = "PostPrompt")]
        public async Task<ActionResult<PromptDTO>> PostController(PromptDTO dto)
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
