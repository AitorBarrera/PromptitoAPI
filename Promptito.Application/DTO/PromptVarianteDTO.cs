using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class PromptVarianteDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TextoPrompt { get; set; } = null!;

    public int PromptId { get; set; }
}
