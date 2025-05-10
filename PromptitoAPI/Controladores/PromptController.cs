using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.DTO;
using Promptito.Application.Interfaces;
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
        public async Task<ActionResult<List<PromptDTO>>> GetAllPrompts()
        {
            return await _context.Prompts
                .ProjectTo<PromptDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("/{id}", Name = "GetPromptById")]
        public async Task<ActionResult<Prompt>> GetPromptById(int id)
        {
            return await _context.Prompts.FindAsync(id);
        }
    }
}
