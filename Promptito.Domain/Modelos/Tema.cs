using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promptito.Domain;

[Table("tema", Schema = "Promptito")]
public partial class Tema
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("TemaId")]
    [InverseProperty("Temas")]
    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();
}
