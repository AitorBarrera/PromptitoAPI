using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Promptito.Domain;

namespace Promptito.Application.Interfaces
{
    public interface IPromptitoPgAdminContext
    {
        public DbSet<Coleccion> Coleccions { get; set; }

        public DbSet<Llm> Llms { get; set; }

        public DbSet<Prompt> Prompts { get; set; }

        public DbSet<Tematica> Tematicas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
