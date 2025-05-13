using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Excepciones;
using Promptito.Application.Interfaces;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Servicios
{
    public class ServicioFavoritos : IServicioFavoritos
    {
        protected readonly IPromptitoDbContext _context;
        protected readonly IMapper _mapper;

        public ServicioFavoritos(IPromptitoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public async Task<ActionResult<UsuarioDTONavegacion>> AddFavorite([FromQuery] int usuarioId, int promptId)
        {
            Usuario? usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (usuario == null)
                throw new ApiException($"Usuario con ID {usuarioId} no encontrado", 404, "user.not_found");


            Prompt? promptToAdd = await _context.Prompts.FindAsync(promptId);

            if (promptToAdd == null)
                throw new ApiException($"Prompt con ID {promptId} no encontrado.", 404, "promptfavorito.not_found");


            usuario.PromptsFavoritos.Add(promptToAdd);
            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioDTONavegacion>(usuario);
        }

        public async Task<ActionResult<string>> RemoveFavorite([FromQuery] int usuarioId, int promptId)
        {
            Usuario? usuario = await _context.Usuarios.Where(u => u.Id == usuarioId).Include(u => u.PromptsFavoritos).Select(u => u).SingleOrDefaultAsync();

            if (usuario == null)
                throw new ApiException($"Usuario con ID {usuarioId} no encontrado", 404, "user.not_found");


            Prompt? promptToRemove = usuario.PromptsFavoritos.SingleOrDefault(p => p.Id == promptId);

            if (promptToRemove == null)
                throw new ApiException($"Prompt con ID {promptId} no encontrado.",404,"promptfavorito.not_found");


            usuario.PromptsFavoritos.Remove(promptToRemove);
            await _context.SaveChangesAsync();

            return $"Prompt '{promptToRemove.Titulo}' borrado de favoritos del usuario '{usuario.Nombre}'.";
        }
    }
}
