using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promptito.Domain;
public class Tematica
{
    public Tematica()
    {
    }

    public int Id { get; set; }

    public string Nombre { get; set; }

    public List<Prompt>? ListaPrompts { get; set; }
}
