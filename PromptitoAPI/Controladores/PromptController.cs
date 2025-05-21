using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.DTO_Post;
using Promptito.Application.Excepciones;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Application.Servicios;
using Promptito.Domain.Modelos;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("")]
    public class PromptController : ControllerBase, IGenericController<Prompt, PromptDTO, PromptDTONavegacion, PromptDTOPost>
    {
        private readonly IServicioCRUD<Prompt, PromptDTO, PromptDTONavegacion, PromptDTOPost> _servicioCRUD;
        private readonly IServicioPromptLlm _servicioPromptLlm;
        private readonly IServicioPromptTematica _servicioPromptTematica;
        private readonly IServicioNavegacionPorId _servicioNavegacionPorId;
        private readonly IServicioPaginacion _servicioPaginacion;

        public PromptController(
            IServicioCRUD<Prompt, PromptDTO, PromptDTONavegacion, PromptDTOPost> servicioCRUD,
            IServicioPromptLlm servicioPromptLlm,
            IServicioPromptTematica servicioPromptTematica, 
            IServicioNavegacionPorId servicioNavegacionPorId,
            IServicioPaginacion servicioPaginacion)
        {
            _servicioCRUD = servicioCRUD;
            _servicioPromptLlm = servicioPromptLlm;
            _servicioPromptTematica = servicioPromptTematica;
            _servicioNavegacionPorId = servicioNavegacionPorId;
            _servicioPaginacion = servicioPaginacion;
        }

        [HttpGet("[controller]", Name = "GetAllPrompt")]
        public async Task<ActionResult<List<PromptDTONavegacion>>> GetAllController()
        {
            return await _servicioCRUD.GetAll();
        }

        [HttpGet("[controller]/paginacion", Name = "GetPaginacionPrompt")]
        public async Task<ActionResult<ObjetoPaginacion<PromptDTONavegacion>>> GetAllPagination([FromQuery] int pagina = 1, [FromQuery] int cantidadPorPagina = 10)
        {
            return await _servicioPaginacion.GetAllPromptsPagination(pagina, cantidadPorPagina);
        }

        [HttpGet("[controller]/dto/paginacion", Name = "GetPaginacionDTOPrompt")]
        public async Task<ActionResult<ObjetoPaginacion<PromptDTO>>> GetAllDTOPagination([FromQuery] int pagina = 1, [FromQuery] int cantidadPorPagina = 10)
        {
            return await _servicioPaginacion.GetAllPromptsDTOPagination(pagina, cantidadPorPagina);
        }

        [HttpGet("[controller]/paginacionFiltrado", Name = "GetPaginacionDTOPromptFiltrado")]
        public async Task<ActionResult<ObjetoPaginacion<PromptDTONavegacion>>> GetFilteredPromptsDTOPagination(
            [FromQuery] string? tituloPrompt,
            [FromQuery] string? nombreAutor,
            [FromQuery] string? contenidoPrompt,
            [FromQuery] string? orderBy,
            [FromQuery] int? idLlm,
            [FromQuery] int? idPromptTematica,
            [FromQuery] int? idUsarioFavorito,
            [FromQuery] Boolean esFavorito,
            [FromQuery] int pagina = 1, 
            [FromQuery] int cantidadPorPagina = 10)
        {
            Filtros filtros = new Filtros();
            filtros.tituloPrompt = tituloPrompt;
            filtros.nombreAutor = nombreAutor;
            filtros.contenidoPrompt = contenidoPrompt;
            filtros.orderBy = orderBy;
            filtros.idLlm = idLlm;
            filtros.idPromptTematica = idPromptTematica;
            filtros.idUsarioFavorito = idUsarioFavorito;
            filtros.esFavorito = esFavorito;

            return await _servicioPaginacion.GetFilteredPromptsPagination(filtros, pagina, cantidadPorPagina);
        }

        [HttpGet("[controller]/dto", Name = "GetAllDTOPrompt")]
        public async Task<ActionResult<List<PromptDTO>>> GetAllDTOController()
        {
            return await _servicioCRUD.GetAllDTO();
        }

        [HttpGet("[controller]/{id}", Name = "GetPromptById")]
        public async Task<ActionResult<PromptDTONavegacion?>> GetByIdController(int id)
        {
            return await _servicioNavegacionPorId.GetByPromptId(id);
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

        [HttpPost("[controller]/addLlm", Name = "AddLlm")]
        public async Task<ActionResult<PromptDTONavegacion>> AddLlmToPrompt([FromQuery] int promptId, int llmId)
        {
            return await _servicioPromptLlm.AddLlmToPrompt(promptId, llmId);
        }

        [HttpDelete("[controller]/RemoveLlm", Name = "RemoveLlm")]
        public async Task<ActionResult<string>> RemoveLlmFromPrompt([FromQuery] int promptId, int llmId)
        {
            return await _servicioPromptLlm.RemoveLlmFromPrompt(promptId, llmId);
        }

        [HttpPost("[controller]/addTematica", Name = "AddTematica")]
        public async Task<ActionResult<PromptDTONavegacion>> AddTematicaToPrompt([FromQuery] int promptId, int TematicaId)
        {
            return await _servicioPromptTematica.AddTematicaToPrompt(promptId, TematicaId);
        }

        [HttpDelete("[controller]/RemoveTematica", Name = "RemoveTematica")]
        public async Task<ActionResult<string>> RemoveTematicaFromPrompt([FromQuery] int promptId, int TematicaId)
        {
            return await _servicioPromptTematica.RemoveTematicaFromPrompt(promptId, TematicaId);
        }
    }
}
