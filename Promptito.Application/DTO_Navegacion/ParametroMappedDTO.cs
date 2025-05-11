using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class ParametroMappedDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoValor { get; set; } = null!;

    public string? ValorPredeterminado { get; set; }

    public virtual ICollection<OpcionParametro> OpcionParametros { get; set; } = new List<OpcionParametro>();

    public virtual PromptVariante PromptVariante { get; set; } = null!;
}
