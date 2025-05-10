using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promptito.Domain.Modelos;

namespace Promptito.Application.DTO
{
    public class PromptDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public DateOnly FechaCreacion { get; set; }

        public int UsuarioCreadorId { get; set; }
        public virtual ICollection<LlmDTO> Llms { get; set; } = new List<LlmDTO>();
    }
}
