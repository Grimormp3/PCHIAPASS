using System;
using System.Collections.Generic;

namespace PCHIAPAS.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime Fecha { get; set; }

    public int IdCliente { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
