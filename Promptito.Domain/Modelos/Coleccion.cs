using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Promptito.Domain;

[Table("coleccion")]
[Index("Nombre", Name = "idx_coleccion_nombre")]
public partial class Coleccion
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("descripcion")]
    public string Descripcion { get; set; } = null!;

    [ForeignKey("ColeccionId")]
    [InverseProperty("Coleccions")]
    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();

    [ForeignKey("ColeccionId")]
    [InverseProperty("Coleccions")]
    public virtual ICollection<Tematica> Tematicas { get; set; } = new List<Tematica>();
}
