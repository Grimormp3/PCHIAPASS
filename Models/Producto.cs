using System;
using System.Collections.Generic;

namespace PCHIAPAS.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Procesador { get; set; } = null!;

    public string Ram { get; set; } = null!;

    public string TarjetaGrafica { get; set; } = null!;

    public string Almacenamiento { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Existencia { get; set; }

    public string? Imagen { get; set; }

    public int IdMarca { get; set; }

    public int IdCategoria { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Marca IdMarcaNavigation { get; set; } = null!;

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
}
