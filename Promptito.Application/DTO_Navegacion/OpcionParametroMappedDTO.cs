using System;
using System.Collections.Generic;
using Promptito.Domain.Modelos;

namespace Promptito.Application.NavegacionDTO;

public partial class OpcionParametroMappedDTO
{
    public int Id { get; set; }

    public string Valor { get; set; } = null!;

    public virtual Parametro Parametro { get; set; } = null!;
}
