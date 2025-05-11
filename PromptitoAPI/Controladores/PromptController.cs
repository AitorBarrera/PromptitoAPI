using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.Interfaces;
using Promptito.Application.NavegacionDTO;
using Promptito.Domain.Modelos;
using Promptito.Persistance;

namespace Promptito.API.Controladores
{
    [ApiController]
    [Route("prompts")]
    public class PromptController : ControllerBase
    {
        private readonly IPromptitoDbContext _context;
        private readonly IMapper _mapper;
        public PromptController(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("", Name = "GetPrompts")]
        public async Task<ActionResult<List<PromptMappedDTO>>> GetAllPrompts()
        {
            return await _context.Prompts
                .ProjectTo<PromptMappedDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id}", Name = "GetPromptById")]
        public async Task<ActionResult<PromptMappedDTO>> GetPromptById([FromRoute] int id)
        {
            PromptMappedDTO dto = await _context.Prompts
            .Where(p => p.Id == id)
            .ProjectTo<PromptMappedDTO>(_mapper.ConfigurationProvider)
            .FirstAsync();

            if (dto == null)
            {
                return NotFound();
            }

            return dto;
        }
    }
}
