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
    internal class TematicaConfiguration : IEntityTypeConfiguration<Tematica>
    {
        public void Configure(EntityTypeBuilder<Tematica> builder)
        {
            builder.ToTable("tematica");

            builder
                .HasIndex(t => t.Nombre)
                .IsUnique();
        }
    }
}
