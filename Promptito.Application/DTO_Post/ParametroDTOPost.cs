using System;
using System.Collections.Generic;

namespace Promptito.Application.DTO_Post;

public partial class ParametroDTOPost
{
    public string Nombre { get; set; } = null!;

    public string TipoValor { get; set; } = null!;

    public string? ValorPredeterminado { get; set; }

    public int PromptVarianteId { get; set; }
}
