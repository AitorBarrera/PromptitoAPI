

using Promptito.Application.DTO;

namespace Promptito.Domain.Modelos;

public partial class TematicaDTONavegacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PromptDTO> Prompts { get; set; } = new List<PromptDTO>();

}
