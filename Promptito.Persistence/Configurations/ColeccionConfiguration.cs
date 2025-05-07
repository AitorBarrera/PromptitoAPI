using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Promptito.Domain;
using Promptito.Domain.Modelos;

namespace Promptito.Persistence.Configurations
{
    internal class ColeccionConfiguration : IEntityTypeConfiguration<Coleccion>
    {
        public void Configure(EntityTypeBuilder<Coleccion> builder)
        {
            builder.ToTable("coleccion");
        }
    }
}
