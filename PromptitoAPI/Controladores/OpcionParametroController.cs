using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class OpcionParametroController : ControllerBase, IGenericController<OpcionParametro, OpcionParametroDTO>
    {
        private readonly IServicioCRUD<OpcionParametro, OpcionParametroDTO> _servicioCRUD;

        public OpcionParametroController(IServicioCRUD<OpcionParametro, OpcionParametroDTO> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }


        [HttpGet("[controller]", Name = "GetAllOpcionParametro")]
        public async Task<ActionResult<List<OpcionParametro>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }


        [HttpGet("[controller]/{id}", Name = "GetOpcionParametroById")]
        public async Task<ActionResult<OpcionParametro>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpPost("[controller]", Name = "PostOpcionParametro")]
        public async Task<ActionResult<OpcionParametroDTO>> PostController(OpcionParametroDTO dto)
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
