using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        protected readonly IPromptitoDbContext _context;
        protected readonly IMapper _mapper;

        public ServicioUsuario(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<UsuarioDTO>> GetByIdClerkDTOController(string idClerk)
        {
            Usuario? usuario = await _context.Usuarios.Where(u => u.IdClerk.Equals(idClerk)).FirstOrDefaultAsync();

            if (usuario == null)
                throw new KeyNotFoundException($"No se encontró el usuario en Clerk con id {idClerk}.");

            return _mapper.Map<UsuarioDTO>(usuario);
        }
    }
}
