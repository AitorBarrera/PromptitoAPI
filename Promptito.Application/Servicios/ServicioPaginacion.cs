using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;

namespace Promptito.Application.Servicios
{
    public class ServicioPaginacion : IServicioPaginacion
    {
        private readonly IPromptitoDbContext _context;
        private readonly IMapper _mapper;

        public ServicioPaginacion(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<ObjetoPaginacion<PromptDTONavegacion>>> GetAllPromptsPagination([FromQuery] int pagina = 1, [FromQuery] int cantidadPorPagina = 10)
        {
            int salto = (pagina - 1) * cantidadPorPagina;

            List<PromptDTONavegacion> listaPrompt = await _context.Prompts
                .OrderByDescending(p => p.FechaCreacion)
                .Skip(salto)
                .Take(cantidadPorPagina)
                .ProjectTo<PromptDTONavegacion>(_mapper.ConfigurationProvider)
                .ToListAsync();

            int cantidadTotal = await _context.Prompts.CountAsync();

            return new ObjetoPaginacion<PromptDTONavegacion>
            {
                Datos = listaPrompt,
                Pagina = pagina,
                CantidadPorPagina = cantidadPorPagina,
                CantidadDePaginas = (int)Math.Ceiling((decimal)cantidadTotal / (decimal)cantidadPorPagina),
                CantidadTotal = cantidadTotal
            };
        }

        public async Task<ActionResult<ObjetoPaginacion<PromptDTO>>> GetAllPromptsDTOPagination([FromQuery] int pagina = 1, [FromQuery] int cantidadPorPagina = 10)
        {
            int salto = (pagina - 1) * cantidadPorPagina;

            List<PromptDTO> listaPrompt = await _context.Prompts
                .OrderByDescending(p => p.FechaCreacion)
                .Skip(salto)
                .Take(cantidadPorPagina)
                .ProjectTo<PromptDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var cantidadTotal = await _context.Prompts.CountAsync();

            return new ObjetoPaginacion<PromptDTO>
            {
                Datos = listaPrompt,
                Pagina = pagina,
                CantidadPorPagina = cantidadPorPagina,
                CantidadDePaginas = (int)Math.Ceiling((decimal)cantidadTotal / (decimal)cantidadPorPagina),
                CantidadTotal = cantidadTotal
            };
        }
    }
}
