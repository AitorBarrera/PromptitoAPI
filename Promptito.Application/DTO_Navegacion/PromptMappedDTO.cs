using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promptito.Domain.Modelos;

namespace Promptito.Application.NavegacionDTO
{
    public class PromptMappedDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public DateOnly FechaCreacion { get; set; }

        public virtual ICollection<PromptVarianteDTO> PromptVariantes { get; set; } = new List<PromptVarianteDTO>();

        public virtual UsuarioDTO UsuarioCreador { get; set; } = null!;     

        public virtual ICollection<LlmDTO> Llms { get; set; } = new List<LlmDTO>();

        public virtual ICollection<TematicaDTO> Tematicas { get; set; } = new List<TematicaDTO>();

        public virtual ICollection<UsuarioDTO> EnFavoritosDe { get; set; } = new List<UsuarioDTO>();
    }
}
