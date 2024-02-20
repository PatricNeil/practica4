using System;
using System.Collections.Generic;

namespace practica4.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string NombreCargo { get; set; } = null!;

    public decimal Salario { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
