using System;
using System.Collections.Generic;

namespace PCHIAPAS.Models;

public partial class MovimientosInventario
{
    public int IdMovimiento { get; set; }

    public int IdProducto { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime Fecha { get; set; }

    public string? Observacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
