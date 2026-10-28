using System;
using System.Collections.Generic;

namespace PCHIAPAS.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
