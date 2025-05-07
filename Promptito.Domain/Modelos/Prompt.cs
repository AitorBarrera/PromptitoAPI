using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Promptito.Domain.Modelos;

namespace Promptito.Domain;

public class Prompt
{
    public Prompt()
    {
    }

    public int Id { get; set; }

    public string Titulo { get; set; }

    public string TextoContenido { get; set; }

    public int UsuarioId { get; set; }

    public DateTime fechaCreacion { get; set; }

    //Atributos de navegacion por relacion
    public Usuario UsuarioCreador { get; set; } = null!;

    public List<Llm> ListaLlms { get; set; } 

    public List<Tematica> ListaTematicas { get; set; }

    public List<Usuario> ListaUsuariosEnFavoritos { get; set; }
    
    public List<Coleccion> ListaColecciones { get; set; }
}
