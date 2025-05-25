using System;
using System.Collections.Generic;
using Promptito.Domain.Modelos;

namespace Promptito.Application.NavegacionDTO;

public partial class OpcionParametroDTONavegacion
{
    public int Id { get; set; }

    public string Valor { get; set; } = null!;

    public virtual ParametroDTO Parametro { get; set; } = null!;
}
