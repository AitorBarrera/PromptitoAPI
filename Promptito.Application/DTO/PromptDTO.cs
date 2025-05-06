using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Application.DTO
{
    public class PromptDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string TextoContenido { get; set; } = null!;

        public int IdUsuarioCreador { get; set; }
    }
}
