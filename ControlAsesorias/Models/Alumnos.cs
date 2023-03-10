using System;
using System.Collections.Generic;

namespace ControlAsesorias.Models;

public partial class Alumnos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string NumeroControl { get; set; } = null!;

    public double Promedio { get; set; }

    public string? Evaluacion { get; set; }

    public virtual ICollection<Asesorias> Asesorias { get; } = new List<Asesorias>();
}
