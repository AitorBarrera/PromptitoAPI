using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class UsuarioDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public bool EstaActivo { get; set; }
}
