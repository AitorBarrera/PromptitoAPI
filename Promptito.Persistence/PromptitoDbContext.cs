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
        modelBuilder.HasDefaultSchema("v2");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PromptitoDbContext).Assembly);
    }
}
