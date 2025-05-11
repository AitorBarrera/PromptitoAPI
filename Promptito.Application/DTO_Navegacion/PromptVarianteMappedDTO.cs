using System;
using System.Collections.Generic;

namespace Promptito.Domain.Modelos;

public partial class PromptVarianteMappedDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string TextoPrompt { get; set; } = null!;

    public virtual ICollection<Parametro> Parametros { get; set; } = new List<Parametro>();

    public virtual Prompt Prompt { get; set; } = null!;
}
