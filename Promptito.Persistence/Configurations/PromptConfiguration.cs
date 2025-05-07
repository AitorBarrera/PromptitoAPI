using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Promptito.Domain;

namespace Promptito.Persistence.Configurations
{
    internal class PromptConfiguration : IEntityTypeConfiguration<Prompt>
    {
        public void Configure(EntityTypeBuilder<Prompt> builder)
        {
            builder.ToTable("prompt");

            builder.HasMany(p => p.ListaColecciones).WithMany(c => c.ListaPrompts);

            builder
                .HasOne(p => p.UsuarioCreador)
                .WithMany(u => u.ListaPromptsCreados)
                .HasForeignKey(p => p.UsuarioId);

            builder
                .HasMany(p => p.ListaUsuariosEnFavoritos)
                .WithMany(u => u.ListaPromptsFavoritos);
        }
    }
}
