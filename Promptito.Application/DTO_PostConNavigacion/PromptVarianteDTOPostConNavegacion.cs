using System;
using System.Collections.Generic;
using Promptito.Application.DTO;

namespace Promptito.Application.DTO_PostConNavegacion;

public partial class PromptVarianteDTOPostConNavegacion
{

    public string Nombre { get; set; } = null!;

    public string TextoPrompt { get; set; } = null!;

    public virtual ICollection<ParametroDTOPostConNavegacion> Parametros { get; set; } = new List<ParametroDTOPostConNavegacion>();

}
