using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Promptito.Domain;
using System.Reflection.Emit;

namespace Promptito.Persistence.Configurations
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .HasIndex(u => u.Nombre)
                .IsUnique();
        }
    }
}
