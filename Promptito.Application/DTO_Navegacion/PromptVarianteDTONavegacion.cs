using System;
using System.Collections.Generic;
using Promptito.Application.DTO;

namespace Promptito.Domain.Modelos;

public partial class PromptVarianteDTONavegacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TextoPrompt { get; set; } = null!;

    public virtual ICollection<ParametroDTONavegacion> Parametros { get; set; } = new List<ParametroDTONavegacion>();

    public virtual PromptDTO Prompt { get; set; } = null!;
}
