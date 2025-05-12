using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO_Post;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class TematicaController : ControllerBase, IGenericController<Tematica, TematicaDTO, TematicaDTONavegacion, TematicaDTOPost>
    {
        private readonly IServicioCRUD<Tematica, TematicaDTO, TematicaDTONavegacion, TematicaDTOPost> _servicioCRUD;

        public TematicaController(IServicioCRUD<Tematica, TematicaDTO, TematicaDTONavegacion, TematicaDTOPost> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }

        [HttpGet("[controller]", Name = "GetAllTematica")]
        public async Task<ActionResult<List<TematicaDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/dto", Name = "GetAllDTOTematica")]
        public async Task<ActionResult<List<TematicaDTO>>> GetAllDTOController()
        {
            return await _servicioCRUD.GetAllDTO();
        }

        [HttpGet("[controller]/{id}", Name = "GetTematicaById")]
        public async Task<ActionResult<TematicaDTONavegacion>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpGet("[controller]/dto/{id}", Name = "GetTematicaDTOById")]
        public async Task<ActionResult<TematicaDTO>> GetByIdDTOController(int id)
        {
            return await _servicioCRUD.GetByIdDTO(id);
        }

        [HttpPost("[controller]", Name = "PostTematica")]
        public async Task<ActionResult<TematicaDTO>> PostController(TematicaDTOPost dto)
        {
            return await _servicioCRUD.Post(dto);
        }

        [HttpPut("[controller]", Name = "UpdateTematica")]
        public async Task<ActionResult<TematicaDTO>> UpdateController(TematicaDTO dto)
        {
            return await _servicioCRUD.Update(dto);
        }

        [HttpDelete("[controller]", Name = "DeleteTematica")]
        public async Task<ActionResult<string?>> DeleteController(int id)
        {
            return await _servicioCRUD.Delete(id);
        }
    }
}
