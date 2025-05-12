using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class ParametroDTONavegacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TipoValor { get; set; } = null!;

    public string? ValorPredeterminado { get; set; }

    public virtual ICollection<OpcionParametroDTO> OpcionParametros { get; set; } = new List<OpcionParametroDTO>();

    public virtual PromptVarianteDTO PromptVariante { get; set; } = null!;
}
