using System;
using System.Collections.Generic;
using Promptito.Application.DTO;
using Promptito.Domain.Modelos;

namespace Promptito.Application.NavegacionDTO;

public partial class LlmDTONavegacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Version { get; set; } = null!;

    public virtual ICollection<PromptDTO> Prompts { get; set; } = new List<PromptDTO>();
}
