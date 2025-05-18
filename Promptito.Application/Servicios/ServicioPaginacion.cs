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

        public async Task<ActionResult<ObjetoPaginacion<PromptDTONavegacion>>> GetFilteredPromptsPagination(Filtros filtros, int pagina = 1, int cantidadPorPagina = 10)
        {
            int salto = (pagina - 1) * cantidadPorPagina;

            //List<PromptDTONavegacion> listaPrompt = await _context.Prompts
            //    .OrderByDescending(p => p.FechaCreacion)
            //    .Where(p => string.IsNullOrEmpty(filtros.tituloPrompt) || p.Titulo.Contains(filtros.tituloPrompt))
            //    .Where(p => string.IsNullOrEmpty(filtros.contenidoPrompt) || p.Descripcion.Contains(filtros.contenidoPrompt))
            //    .Where(p => string.IsNullOrEmpty(filtros.nombreAutor) || p.UsuarioCreador.Nombre.Contains(filtros.nombreAutor))
            //    .Where(p => filtros.idLlm.HasValue || p.Llms.Any(l => l.Id == filtros.idLlm))
            //    .Where(p => filtros.idPromptTematica.HasValue || p.Tematicas.Any(t => t.Id == filtros.idPromptTematica))
            //    .Where(p => filtros.esFavorito.HasValue || p.EnFavoritosDe.Any(u => u.Id == filtros.idUsarioFavorito))
            //    .Skip(salto)
            //    .Take(cantidadPorPagina)
            //    .ProjectTo<PromptDTONavegacion>(_mapper.ConfigurationProvider)
            //    .ToListAsync();

            var query = _context.Prompts.AsQueryable();

            if (!string.IsNullOrEmpty(filtros.tituloPrompt))
            {
                query = query.Where(p => p.Titulo.Contains(filtros.tituloPrompt));
            }

            if (!string.IsNullOrEmpty(filtros.contenidoPrompt))
            {
                query = query
                    .Include(p => p.PromptVariantes)
                    .Where(p => p.PromptVariantes
                        .Any(pv => pv.TextoPrompt.Contains(filtros.contenidoPrompt, StringComparison.OrdinalIgnoreCase))
                        );
            }

            if (!string.IsNullOrEmpty(filtros.nombreAutor))
            {
                query = query.Where(p => p.UsuarioCreador.Nombre.Contains(filtros.nombreAutor));
            }

            if (filtros.idLlm.HasValue)
            {
                query = query.Include(p => p.Llms).Where(p => p.Llms.Any(l => l.Id == filtros.idLlm));
            }

            if (filtros.idPromptTematica.HasValue)
            {
                query = query.Include(p => p.Tematicas).Where(p => p.Tematicas.Any(t => t.Id == filtros.idPromptTematica));
            }


            if (filtros.esFavorito)
            {
               query = query.Include(p => p.EnFavoritosDe).Where(p => p.EnFavoritosDe.Any(u => u.Id == filtros.idUsarioFavorito));
            }

            List<PromptDTONavegacion> listaPrompt = await query
                .OrderByDescending(p => p.FechaCreacion)
                .Skip(salto)
                .Take(cantidadPorPagina)
                .ProjectTo<PromptDTONavegacion>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var cantidadTotal = await query.CountAsync();

            return new ObjetoPaginacion<PromptDTONavegacion>
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
