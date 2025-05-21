using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public string? IdClerk { get; set; }

    public bool EstaActivo { get; set; }

    public virtual ICollection<Prompt> PromptsCreados { get; set; } = new List<Prompt>();

    public virtual ICollection<Prompt> PromptsFavoritos { get; set; } = new List<Prompt>();
}
