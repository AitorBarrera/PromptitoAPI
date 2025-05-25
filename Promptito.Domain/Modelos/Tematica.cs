using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class Tematica
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();
}
