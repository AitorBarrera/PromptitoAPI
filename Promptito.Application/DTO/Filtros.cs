using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.DTO
{
    public class Filtros
    {
        public Filtros()
        {
        }

        public string? tituloPrompt { get; set; } = string.Empty;

        public string? nombreAutor { get; set; } = string.Empty;

        public string? contenidoPrompt { get; set; } = string.Empty;

        public string? orderBy { get; set; } = string.Empty;

        public int? idLlm { get; set; }

        public int? idPromptTematica { get; set; }

        public int? idUsarioFavorito { get; set; }

        public Boolean esFavorito { get; set; } = false;


    }
}
