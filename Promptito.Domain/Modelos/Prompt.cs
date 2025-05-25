using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class Prompt
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }

    public int UsuarioCreadorId { get; set; }

    public virtual ICollection<PromptVariante> PromptVariantes { get; set; } = new List<PromptVariante>();

    public virtual Usuario UsuarioCreador { get; set; } = null!;

    public virtual ICollection<Llm> Llms { get; set; } = new List<Llm>();

    public virtual ICollection<Tematica> Tematicas { get; set; } = new List<Tematica>();

    public virtual ICollection<Usuario> EnFavoritosDe { get; set; } = new List<Usuario>();
}
