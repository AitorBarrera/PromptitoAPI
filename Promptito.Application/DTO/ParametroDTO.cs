using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class ParametroDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoValor { get; set; } = null!;

    public string? ValorPredeterminado { get; set; }

    public int PromptVarianteId { get; set; }
}
