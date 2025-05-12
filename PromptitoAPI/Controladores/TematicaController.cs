using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class TematicaController : ControllerBase, IGenericController<Tematica, TematicaDTO>
    {
        private readonly IServicioCRUD<Tematica, TematicaDTO> _servicioCRUD;

        public TematicaController(IServicioCRUD<Tematica, TematicaDTO> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }


        [HttpGet("[controller]", Name = "GetAllTematica")]
        public async Task<ActionResult<List<Tematica>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }


        [HttpGet("[controller]/{id}", Name = "GetTematicaById")]
        public async Task<ActionResult<Tematica>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpPost("[controller]", Name = "PostTematica")]
        public async Task<ActionResult<TematicaDTO>> PostController(TematicaDTO dto)
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
