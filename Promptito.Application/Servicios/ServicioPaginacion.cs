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


            var query = _context.Prompts.AsQueryable();

            if (!string.IsNullOrEmpty(filtros.tituloPrompt))
            {
                query = query.Where(p => p.Titulo.ToLower().Contains(filtros.tituloPrompt.ToLower()));
            }

            if (!string.IsNullOrEmpty(filtros.nombreAutor))
            {
                query = query.Where(p => p.UsuarioCreador.Nombre.ToLower().Contains(filtros.nombreAutor.ToLower()));
            }

            if (!string.IsNullOrEmpty(filtros.contenidoPrompt))
            {
                query = query
                    .Include(p => p.PromptVariantes)
                    .Where(p => p.PromptVariantes
                        .Any(pv => pv.TextoPrompt.ToLower().Contains(filtros.contenidoPrompt.ToLower()))
                        );
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

            switch (filtros.orderBy)
            {
                case "fechaAsc":
                    query = query.OrderBy(p => p.Id);

                break;

                case "fechaDesc":
                    query = query.OrderByDescending(p => p.Id);

                    break;

                case "tituloAsc":
                    query = query.OrderBy(p => p.Titulo);

                    break;

                case "tituloDesc":
                    query = query.OrderByDescending(p => p.Titulo);

                    break;

                case "popularidad":
                    query = query.OrderByDescending(p => p.EnFavoritosDe.Count());

                    break;

                default:
                    query = query.OrderByDescending(p => p.EnFavoritosDe.Count());

                    break;
            }

            List<PromptDTONavegacion> listaPrompt = await query
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
