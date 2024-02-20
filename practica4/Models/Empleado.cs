using System;
using System.Collections.Generic;

namespace practica4.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string Ci { get; set; } = null!;

    public int IdDireccion { get; set; }

    public decimal? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public int IdCargo { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Direccione IdDireccionNavigation { get; set; } = null!;
}
