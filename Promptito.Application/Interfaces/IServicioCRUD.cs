

namespace Promptito.Application.Interfaces
{
    public interface IServicioCRUD<TEntity, TDto, TDto_Navegacion, TDto_Post>
    {
        Task<List<TDto_Navegacion>> GetAll();

        Task<List<TDto>> GetAllDTO();

        Task<TDto_Navegacion?> GetById(int id);

        Task<TDto> GetByIdDTO(int id);

        Task<TDto> Post(TDto_Post dto);

        Task<TDto> Update(TDto dto);

        Task<string?> Delete(int id);
    }
}
