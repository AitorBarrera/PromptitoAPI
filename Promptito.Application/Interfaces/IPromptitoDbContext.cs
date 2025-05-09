using System;
using Microsoft.EntityFrameworkCore;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Interfaces
{
    public interface IPromptitoDbContext
    {
        public  DbSet<Llm> Llms { get; set; }

        public  DbSet<OpcionParametro> OpcionParametros { get; set; }

        public  DbSet<Parametro> Parametros { get; set; }

        public  DbSet<Prompt> Prompts { get; set; }

        public  DbSet<PromptVariante> PromptVariantes { get; set; }

        public  DbSet<Tematica> Tematicas { get; set; }

        public  DbSet<Usuario> Usuarios { get; set; }
    }
}
