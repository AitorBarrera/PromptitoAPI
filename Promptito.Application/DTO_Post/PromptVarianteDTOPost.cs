using System;
using System.Collections.Generic;

namespace Promptito.Application.DTO_Post;

public partial class PromptVarianteDTOPost
{

    public string Nombre { get; set; } = null!;

    public string TextoPrompt { get; set; } = null!;

    public int PromptId { get; set; }
}
