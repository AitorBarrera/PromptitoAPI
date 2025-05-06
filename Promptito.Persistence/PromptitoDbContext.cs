using Microsoft.EntityFrameworkCore;
using Promptito;
using Promptito.Application.Interfaces;
using Promptito.Domain;

namespace Promptito.Persistence;

public partial class PromptitoDbContext : DbContext, IPromptitoDbContext
{
    public PromptitoDbContext()
    {
    }

    public PromptitoDbContext(DbContextOptions<PromptitoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Llm> Llms { get; set; }

    public virtual DbSet<Prompt> Prompts { get; set; }

    public virtual DbSet<Tema> Temas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-wild-violet-a2frf8n2.eu-central-1.aws.neon.tech;Database=PromptitoDB;Username=Admin;Password=npg_q9KhQYwUJ3Px");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Llm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("llm_pkey");
        });

        modelBuilder.Entity<Prompt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prompt_pkey");

            entity.HasOne(d => d.IdUsuarioCreadorNavigation).WithMany(p => p.Prompts).HasConstraintName("prompt_id_usuario_creador_fkey");

            entity.HasMany(d => d.Llms).WithMany(p => p.Prompts)
                .UsingEntity<Dictionary<string, object>>(
                    "PromptLlm",
                    r => r.HasOne<Llm>().WithMany()
                        .HasForeignKey("LlmId")
                        .HasConstraintName("prompt_llm_llm_id_fkey"),
                    l => l.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .HasConstraintName("prompt_llm_prompt_id_fkey"),
                    j =>
                    {
                        j.HasKey("PromptId", "LlmId").HasName("prompt_llm_pkey");
                        j.ToTable("prompt_llm", "Promptito");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                        j.IndexerProperty<int>("LlmId").HasColumnName("llm_id");
                    });

            entity.HasMany(d => d.Temas).WithMany(p => p.Prompts)
                .UsingEntity<Dictionary<string, object>>(
                    "PromptTema",
                    r => r.HasOne<Tema>().WithMany()
                        .HasForeignKey("TemaId")
                        .HasConstraintName("prompt_tema_tema_id_fkey"),
                    l => l.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .HasConstraintName("prompt_tema_prompt_id_fkey"),
                    j =>
                    {
                        j.HasKey("PromptId", "TemaId").HasName("prompt_tema_pkey");
                        j.ToTable("prompt_tema", "Promptito");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                        j.IndexerProperty<int>("TemaId").HasColumnName("tema_id");
                    });
        });

        modelBuilder.Entity<Tema>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tema_pkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.HasMany(d => d.PromptsNavigation).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "PromptFavorito",
                    r => r.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .HasConstraintName("favorito_prompt_id_fkey"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("favorito_usuario_id_fkey"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "PromptId").HasName("favorito_pkey");
                        j.ToTable("prompt_favorito", "Promptito");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("usuario_id");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
