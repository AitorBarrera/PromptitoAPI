using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain;
using Promptito.Domain.Modelos;

namespace Promptito.Persistence;

public partial class PromptitoDbContext : DbContext, IPromptitoDbContext
{
    public PromptitoDbContext(DbContextOptions<PromptitoDbContext> options)
        : base(options)
    {
    }

    public DbSet<Llm> Llms { get; set; }

    public DbSet<Prompt> Prompts { get; set; }

    public DbSet<Tematica> Temas { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Coleccion> Colecciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
        .HasIndex(u => u.Email)
        .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Nombre)
            .IsUnique();

        modelBuilder.Entity<Llm>()
            .HasIndex(l => new { l.Nombre, l.Version })
            .IsUnique();

        modelBuilder.Entity<Tematica>()
            .HasIndex(t => t.Nombre)
            .IsUnique();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PromptitoDbContext).Assembly);
    }
}
