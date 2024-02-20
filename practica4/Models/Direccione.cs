using System;
using System.Collections.Generic;

namespace practica4.Models;

public partial class Direccione
{
    public int IdDireccion { get; set; }

    public string? Calle { get; set; }

    public string? Ciudad { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
