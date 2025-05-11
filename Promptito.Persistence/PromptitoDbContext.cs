using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Promptito.Domain.Modelos;
using Promptito.Application.Interfaces;

namespace Promptito.Persistance;

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

    public virtual DbSet<OpcionParametro> OpcionParametros { get; set; }

    public virtual DbSet<Parametro> Parametros { get; set; }

    public virtual DbSet<Prompt> Prompts { get; set; }

    public virtual DbSet<PromptVariante> PromptVariantes { get; set; }

    public virtual DbSet<Tematica> Tematicas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:PromptitoDbConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Llm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("llm_pkey");

            entity.ToTable("llm");

            entity.HasIndex(e => new { e.Nombre, e.Version }, "llm_nombre_version_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.Version)
                .HasMaxLength(10)
                .HasColumnName("version");
        });

        modelBuilder.Entity<OpcionParametro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("opcion_parametro_pkey");

            entity.ToTable("opcion_parametro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParametroId).HasColumnName("parametro_id");
            entity.Property(e => e.Valor)
                .HasMaxLength(30)
                .HasColumnName("valor");

            entity.HasOne(d => d.Parametro).WithMany(p => p.OpcionParametros)
                .HasForeignKey(d => d.ParametroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("opcion_parametro_parametro_id_fkey");
        });

        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("parametro_pkey");

            entity.ToTable("parametro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.PromptVarianteId).HasColumnName("prompt_variante_id");
            entity.Property(e => e.TipoValor)
                .HasMaxLength(20)
                .HasColumnName("tipo_valor");
            entity.Property(e => e.ValorPredeterminado)
                .HasMaxLength(30)
                .HasColumnName("valor_predeterminado");

            entity.HasOne(d => d.PromptVariante).WithMany(p => p.Parametros)
                .HasForeignKey(d => d.PromptVarianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("parametro_prompt_variante_id_fkey");
        });

        modelBuilder.Entity<Prompt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prompt_pkey");

            entity.ToTable("prompt");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");
            entity.Property(e => e.UsuarioCreadorId).HasColumnName("usuario_creador_id");

            entity.HasOne(d => d.UsuarioCreador).WithMany(p => p.PromptsCreados)
                .HasForeignKey(d => d.UsuarioCreadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prompt_usuario_creador_id_fkey");

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

            entity.HasMany(d => d.EnFavoritosDe).WithMany(p => p.PromptsFavoritos)
                .UsingEntity<Dictionary<string, object>>(
                    "Favorito",
                    r => r.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("favorito_usuario_id_fkey"),
                    l => l.HasOne<Prompt>().WithMany()
                        .HasForeignKey("PromptId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("favorito_prompt_id_fkey"),
                    j =>
                    {
                        j.HasKey("PromptId", "UsuarioId").HasName("favorito_pkey");
                        j.ToTable("favorito");
                        j.IndexerProperty<int>("PromptId").HasColumnName("prompt_id");
                        j.IndexerProperty<int>("UsuarioId").HasColumnName("usuario_id");
                    });
        });

        modelBuilder.Entity<PromptVariante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prompt_variante_pkey");

            entity.ToTable("prompt_variante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.PromptId).HasColumnName("prompt_id");
            entity.Property(e => e.TextoPrompt).HasColumnName("texto_prompt");

            entity.HasOne(d => d.Prompt).WithMany(p => p.PromptVariantes)
                .HasForeignKey(d => d.PromptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prompt_variante_prompt_id_fkey");
        });

        modelBuilder.Entity<Tematica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tematica_pkey");

            entity.ToTable("tematica");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "usuario_email_key").IsUnique();

            entity.HasIndex(e => e.Nombre, "usuario_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(300)
                .HasColumnName("avatar_url");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.EstaActivo).HasColumnName("esta_activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(500)
                .HasColumnName("password_hash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
