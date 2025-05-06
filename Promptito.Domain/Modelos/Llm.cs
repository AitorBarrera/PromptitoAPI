using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promptito.Domain;

[Table("llm", Schema = "Promptito")]
public partial class Llm
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("LlmId")]
    [InverseProperty("Llms")]
    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();
}
