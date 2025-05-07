using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promptito.Domain.Modelos
{
    public class Coleccion
    {
        public Coleccion() {
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        //Navegacion
        public List<Prompt> ListaPrompts { get; set; }
    }
}
