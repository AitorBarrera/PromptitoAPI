using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Promptito.Domain;

[Table("tematica")]
[Index("Nombre", Name = "idx_tematica_nombre")]
public partial class Tematica
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [ForeignKey("TematicaId")]
    [InverseProperty("Tematicas")]
    public virtual ICollection<Coleccion> Coleccions { get; set; } = new List<Coleccion>();

    [ForeignKey("TematicaId")]
    [InverseProperty("Tematicas")]
    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();
}
