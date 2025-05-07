using Microsoft.EntityFrameworkCore;
using Promptito.Domain;

namespace Promptito.Application.Interfaces
{
    public interface IPromptitoDbContext
    {
        public DbSet<Llm> Llms { get; set; }

        public DbSet<Prompt> Prompts { get; set; }

        public DbSet<Tematica> Temas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
