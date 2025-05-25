using System;
using System.Collections.Generic;

namespace Promptito.Application.DTO_PostConNavegacion;

public partial class ParametroDTOPostConNavegacion
{
    public string Nombre { get; set; } = null!;

    public string TipoValor { get; set; } = null!;

    public string? ValorPredeterminado { get; set; }

    public virtual ICollection<OpcionParametroDTOPostConNavegacion> OpcionParametros { get; set; } = new List<OpcionParametroDTOPostConNavegacion>();

}
