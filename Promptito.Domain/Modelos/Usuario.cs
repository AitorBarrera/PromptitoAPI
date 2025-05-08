using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Promptito.Domain;

[Table("usuario")]
[Index("Email", Name = "idx_usuario_email")]
[Index("Nombre", Name = "idx_usuario_nombre")]
[Index("Email", Name = "usuario_email_key", IsUnique = true)]
[Index("Nombre", Name = "usuario_nombre_key", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column("avatar_url")]
    [StringLength(255)]
    public string AvatarUrl { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [InverseProperty("Usuariocreador")]
    public virtual ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();

    [ForeignKey("UsuarioId")]
    [InverseProperty("Usuarios")]
    public virtual ICollection<Prompt> PromptsNavigation { get; set; } = new List<Prompt>();
}
