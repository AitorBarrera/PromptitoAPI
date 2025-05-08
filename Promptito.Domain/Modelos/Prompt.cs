using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Promptito.Domain  ;

[Table("prompt")]
[Index("Titulo", Name = "idx_prompt_titulo")]
public partial class Prompt
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    [StringLength(255)]
    public string Titulo { get; set; } = null!;

    [Column("texto_contenido")]
    public string TextoContenido { get; set; } = null!;

    [Column("descripcion")]
    public string Descripcion { get; set; } = null!;

    [Column("fecha_creacion")]
    public DateOnly FechaCreacion { get; set; }

    [Column("usuariocreador_id")]
    public int UsuariocreadorId { get; set; }

    [ForeignKey("UsuariocreadorId")]
    [InverseProperty("Prompts")]
    public virtual Usuario Usuariocreador { get; set; } = null!;

    [ForeignKey("PromptId")]
    [InverseProperty("Prompts")]
    public virtual ICollection<Coleccion> Coleccions { get; set; } = new List<Coleccion>();

    [ForeignKey("PromptId")]
    [InverseProperty("Prompts")]
    public virtual ICollection<Llm> Llms { get; set; } = new List<Llm>();

    [ForeignKey("PromptId")]
    [InverseProperty("Prompts")]
    public virtual ICollection<Tematica> Tematicas { get; set; } = new List<Tematica>();

    [ForeignKey("PromptId")]
    [InverseProperty("PromptsNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
