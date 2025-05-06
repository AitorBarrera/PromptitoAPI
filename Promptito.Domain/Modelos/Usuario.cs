using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Promptito.Domain;

[Table("usuario", Schema = "Promptito")]
[Index("Email", Name = "usuario_email_key", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = null!;

    [Column("avatar_url")]
    public string? AvatarUrl { get; set; }

    [InverseProperty("IdUsuarioCreadorNavigation")]
    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("Usuarios")]
    public virtual ICollection<Prompt> PromptsNavigation { get; set; } = new List<Prompt>();
}
