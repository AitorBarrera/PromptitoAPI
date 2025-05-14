using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Excepciones;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Servicios
{
    public class ServicioNavegacionPorId : IServicioNavegacionPorId
    {
        private readonly IPromptitoDbContext _context;
        private readonly IMapper _mapper;

        public ServicioNavegacionPorId(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<LlmDTONavegacion?>> GetByLlmId(int id)
        {
            LlmDTONavegacion? entity = await _context.Llms.Where(e => e.Id == id)
                .Include(e => e.Prompts)
                .ProjectTo<LlmDTONavegacion>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (entity == null) throw new ApiException($"No se encontró la entidad con id {id}.", 404);

            return entity;
        }

        public async Task<ActionResult<OpcionParametroDTONavegacion?>> GetByOpcionParametroId(int id)
        {
            OpcionParametroDTONavegacion? entity = await _context.OpcionParametros.Where(e => e.Id == id)
                .Include(e => e.Parametro)
                .ProjectTo<OpcionParametroDTONavegacion>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (entity == null) throw new ApiException($"No se encontró la entidad con id {id}.", 404);

            return entity;
        }

        public async Task<ActionResult<ParametroDTONavegacion?>> GetByParametroId(int id)
        {
            ParametroDTONavegacion? entity = await _context.Parametros.Where(e => e.Id == id)
                .Include(e => e.OpcionParametros)
                .Include(e => e.PromptVariante)
                .ProjectTo<ParametroDTONavegacion>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (entity == null) throw new ApiException($"No se encontró la entidad con id {id}.", 404);

            return entity;
        }

        public async Task<ActionResult<PromptDTONavegacion?>> GetByPromptId(int id)
        {
            PromptDTONavegacion? entity = await _context.Prompts.Where(p => p.Id == id)
                .Include(e => e.Llms)
                .Include(e => e.Tematicas)
                .ProjectTo<PromptDTONavegacion>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (entity == null) throw new ApiException($"No se encontró la entidad con id {id}.", 404);

            return entity;
        }

        public async Task<ActionResult<PromptVarianteDTONavegacion?>> GetByPromptVarianteId(int id)
        {
            PromptVarianteDTONavegacion? entity = await _context.PromptVariantes.Where(p => p.Id == id)
                .Include(e => e.Parametros)
                .ProjectTo<PromptVarianteDTONavegacion>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (entity == null) throw new ApiException($"No se encontró la entidad con id {id}.", 404);

            return entity;
        }
        public async Task<ActionResult<TematicaDTONavegacion?>> GetByTematicaId(int id)
        {
            TematicaDTONavegacion? entity = await _context.Tematicas.Where(p => p.Id == id)
                .Include(e => e.Prompts)
                .ProjectTo<TematicaDTONavegacion>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (entity == null) throw new ApiException($"No se encontró la entidad con id {id}.", 404);

            return entity;
        }
        public async Task<ActionResult<UsuarioDTONavegacion?>> GetByUsuarioId(int id)
        {
            UsuarioDTONavegacion? entity = await _context.Usuarios.Where(p => p.Id == id)
                .Include(e => e.PromptsCreados)
                .Include(e => e.PromptsFavoritos)
                .ProjectTo<UsuarioDTONavegacion>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (entity == null) throw new ApiException($"No se encontró la entidad con id {id}.", 404);

            return entity;
        }
    }
}
