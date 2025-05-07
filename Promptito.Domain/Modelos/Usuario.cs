using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promptito.Domain;

public partial class Usuario
{
    public Usuario()
    {
    }

    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    //Navegacion
    public List<Prompt>? ListaPromptsCreados { get; set; }

    public List<Prompt>? ListaPromptsFavoritos { get; set; }
}
