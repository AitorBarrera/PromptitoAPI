using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promptito.Domain;

[Table("prompt", Schema = "Promptito")]
public partial class Prompt
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(150)]
    public string Titulo { get; set; } = null!;

    [Column("texto_contenido")]
    public string TextoContenido { get; set; } = null!;

    [Column("id_usuario_creador")]
    public int IdUsuarioCreador { get; set; }

    [ForeignKey("IdUsuarioCreador")]
    [InverseProperty("Prompts")]
    public virtual Usuario IdUsuarioCreadorNavigation { get; set; } = null!;

    [ForeignKey("PromptId")]
    [InverseProperty("Prompts")]
    public virtual ICollection<Llm> Llms { get; set; } = new List<Llm>();

    [ForeignKey("PromptId")]
    [InverseProperty("Prompts")]
    public virtual ICollection<Tema> Temas { get; set; } = new List<Tema>();

    [ForeignKey("PromptId")]
    [InverseProperty("PromptsNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
