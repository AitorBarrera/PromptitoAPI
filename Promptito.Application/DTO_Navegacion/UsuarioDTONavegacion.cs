using System;
using System.Collections.Generic;
using Promptito.Application.DTO;

namespace Promptito.Domain.Modelos;

public partial class UsuarioDTONavegacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public bool EstaActivo { get; set; }

    public virtual ICollection<PromptDTO> PromptsCreados { get; set; } = new List<PromptDTO>();

    public virtual ICollection<PromptDTO> PromptsFavoritos { get; set; } = new List<PromptDTO>();
}
