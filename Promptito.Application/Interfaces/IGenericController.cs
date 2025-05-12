using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;

namespace Promptito.Application.Interfaces
{
    public interface IGenericController<TEntity, TDto, TDto_Navegacion, TDto_Post>
        where TEntity : class
        where TDto : class
        where TDto_Navegacion : class
        where TDto_Post : class

    {
        Task<ActionResult<List<TDto_Navegacion>>> GetAllController();

        Task<ActionResult<List<TDto>>> GetAllDTOController();

        Task<ActionResult<TDto_Navegacion>> GetByIdController(int id);

        Task<ActionResult<TDto>> GetByIdDTOController(int id);

        Task<ActionResult<TDto>> PostController(TDto_Post dto);

        Task<ActionResult<TDto>> UpdateController(TDto dto);

        Task<ActionResult<string?>> DeleteController(int id);
    }
}
