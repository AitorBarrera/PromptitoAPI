using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class LlmDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;
}
