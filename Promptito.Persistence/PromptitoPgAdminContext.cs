using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Promptito.Application.Interfaces;
using Promptito.Domain;

namespace Promptito.Persistence;

public partial class PromptitoPgAdminContext : DbContext, IPromptitoPgAdminContext
{
    public PromptitoPgAdminContext()
    {
    }

    public PromptitoPgAdminContext(DbContextOptions<PromptitoPgAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coleccion> Coleccions { get; set; }

    public virtual DbSet<Llm> Llms { get; set; }

    public virtual DbSet<Prompt> Prompts { get; set; }

    public virtual DbSet<Tematica> Tematicas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-wild-violet-a2frf8n2.eu-central-1.aws.neon.tech;Database=Promptito-pgAdmin;Username=Admin;Password=npg_q9KhQYwUJ3Px");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coleccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("coleccion_pkey");
        });

        modelBuilder.Entity<Llm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("llm_pkey");
        });

        modelBuilder.Entity<Prompt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prompt_pkey");

            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("CURRENT_DATE");

            entity.HasOne(d => d.Usuariocreador).WithMany(p => p.Prompts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prompt_usuariocreador_id_fkey");

            entity.HasMany(d => d.Coleccions).WithMany(p => p.Prompts)
                .UsingEntity<Dictionary<string, object>>(
                    "PromptColeccion",
                    r => r.HasOne<Coleccion>().WithMany()
                        .HasForeignKey("ColeccionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prompt_coleccion_coleccion_id_fkey"),
                    l => l.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prompt_coleccion_prompt_id_fkey"),
                    j =>
                    {
                        j.HasKey("PromptId", "ColeccionId").HasName("prompt_coleccion_pkey");
                        j.ToTable("prompt_coleccion");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                        j.IndexerProperty<int>("ColeccionId").HasColumnName("coleccion_id");
                    });

            entity.HasMany(d => d.Llms).WithMany(p => p.Prompts)
                .UsingEntity<Dictionary<string, object>>(
                    "PromptLlm",
                    r => r.HasOne<Llm>().WithMany()
                        .HasForeignKey("LlmId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prompt_llm_llm_id_fkey"),
                    l => l.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prompt_llm_prompt_id_fkey"),
                    j =>
                    {
                        j.HasKey("PromptId", "LlmId").HasName("prompt_llm_pkey");
                        j.ToTable("prompt_llm");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                        j.IndexerProperty<int>("LlmId").HasColumnName("llm_id");
                    });

            entity.HasMany(d => d.Tematicas).WithMany(p => p.Prompts)
                .UsingEntity<Dictionary<string, object>>(
                    "PromptTematica",
                    r => r.HasOne<Tematica>().WithMany()
                        .HasForeignKey("TematicaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prompt_tematica_tematica_id_fkey"),
                    l => l.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("prompt_tematica_prompt_id_fkey"),
                    j =>
                    {
                        j.HasKey("PromptId", "TematicaId").HasName("prompt_tematica_pkey");
                        j.ToTable("prompt_tematica");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                        j.IndexerProperty<int>("TematicaId").HasColumnName("tematica_id");
                    });

            entity.HasMany(d => d.Usuarios).WithMany(p => p.PromptsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioFavorito",
                    r => r.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("usuario_favorito_usuario_id_fkey"),
                    l => l.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("usuario_favorito_prompt_id_fkey"),
                    j =>
                    {
                        j.HasKey("PromptId", "UsuarioId").HasName("usuario_favorito_pkey");
                        j.ToTable("usuario_favorito");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("usuario_id");
                    });
        });

        modelBuilder.Entity<Tematica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tematica_pkey");

            entity.HasMany(d => d.Coleccions).WithMany(p => p.Tematicas)
                .UsingEntity<Dictionary<string, object>>(
                    "TematicaColeccion",
                    r => r.HasOne<Coleccion>().WithMany()
                        .HasForeignKey("ColeccionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tematica_coleccion_coleccion_id_fkey"),
                    l => l.HasOne<Tematica>().WithMany()
                        .HasForeignKey("TematicaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tematica_coleccion_tematica_id_fkey"),
                    j =>
                    {
                        j.HasKey("TematicaId", "ColeccionId").HasName("tematica_coleccion_pkey");
                        j.ToTable("tematica_coleccion");
                        j.IndexerProperty<int>("TematicaId").HasColumnName("tematica_id");
                        j.IndexerProperty<int>("ColeccionId").HasColumnName("coleccion_id");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
