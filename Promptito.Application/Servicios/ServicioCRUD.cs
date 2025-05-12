using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;

namespace Promptito.Application.Servicios
{
    public class ServicioCRUD<TEntity, TDto, TDto_Navegacion, TDto_Post> : ControllerBase, IServicioCRUD<TEntity, TDto, TDto_Navegacion, TDto_Post>
    where TEntity : class
    where TDto : class
    where TDto_Navegacion : class
    where TDto_Post : class
    {
        protected readonly IPromptitoDbContext _context;
        protected readonly IMapper _mapper;

        public ServicioCRUD(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TDto_Navegacion>> GetAll()
        {
            return await _context.Set<TEntity>()
                .ProjectTo<TDto_Navegacion>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TDto_Navegacion> GetById(int id)
    {
            TEntity? entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"No se encontró la entidad con id {id}.");
            }

            return _mapper.Map<TDto_Navegacion>(entity);
        }

        public async Task<TDto> Post(TDto_Post dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            _context.Set<TEntity>().Add(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);

        }

        public async Task<TDto> Update(TDto dto)
        {
            TEntity entity = _mapper.Map<TEntity>(dto);

            _context.Set<TEntity>().Update(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }

        public async Task<string?> Delete(int id)
        {
            TEntity? entity = await _context.Set<TEntity>().FindAsync(id);


            if (entity == null)
            {
                return null;
            }

            _context.Set<TEntity>().Remove(entity);

            await _context.SaveChangesAsync();

            return $"Prompt con id {id} borrado.";
        }
    }
}
