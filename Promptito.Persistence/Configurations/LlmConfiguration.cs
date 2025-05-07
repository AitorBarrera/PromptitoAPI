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
    internal class LlmConfiguration : IEntityTypeConfiguration<Llm>
    {
        public void Configure(EntityTypeBuilder<Llm> builder)
        {
            builder.ToTable("llm");

            builder
                .HasIndex(l => new { l.Nombre, l.Version })
                .IsUnique();
        }
    }
}
