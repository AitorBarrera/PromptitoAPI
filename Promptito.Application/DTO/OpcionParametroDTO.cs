using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class OpcionParametroDTO
{
    public int Id { get; set; }

    public string Valor { get; set; } = null!;

    public int ParametroId { get; set; }
}
