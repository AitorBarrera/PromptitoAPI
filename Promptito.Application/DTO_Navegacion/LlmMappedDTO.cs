using System;
using System.Collections.Generic;
using Promptito.Domain.Modelos;

namespace Promptito.Application.NavegacionDTO;

public partial class LlmMappedDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Version { get; set; } = null!;

    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();
}
