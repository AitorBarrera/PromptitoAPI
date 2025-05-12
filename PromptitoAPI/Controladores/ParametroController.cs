using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class ParametroController : ControllerBase, IGenericController<Parametro, ParametroDTO>
    {
        private readonly IServicioCRUD<Parametro, ParametroDTO> _servicioCRUD;

        public ParametroController(IServicioCRUD<Parametro, ParametroDTO> servicioCRUD)
        {
            _servicioCRUD = servicioCRUD;
        }


        [HttpGet("[controller]", Name = "GetAllParametro")]
        public async Task<ActionResult<List<Parametro>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }


        [HttpGet("[controller]/{id}", Name = "GetParametroById")]
        public async Task<ActionResult<Parametro>> GetByIdController(int id)
        {
            return await _servicioCRUD.GetById(id);
        }

        [HttpPost("[controller]", Name = "PostParametro")]
        public async Task<ActionResult<ParametroDTO>> PostController(ParametroDTO dto)
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
