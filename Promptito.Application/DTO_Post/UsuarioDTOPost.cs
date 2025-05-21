using System;
using System.Collections.Generic;

namespace Promptito.Application.DTO_Post;

public partial class UsuarioDTOPost
{

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public string? IdClerk { get; set; }

    public bool EstaActivo { get; set; }
}
