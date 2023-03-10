using System;
using System.Collections.Generic;

namespace ControlAsesorias.Models;

public partial class Asesorias
{
    public int Id { get; set; }

    public string? Asesor { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdTutorado { get; set; }

    public string? Hora { get; set; }

    public virtual Alumnos? IdTutoradoNavigation { get; set; }
}
