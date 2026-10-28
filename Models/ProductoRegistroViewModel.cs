
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PCHIAPAS.Models
{
    public class ProductoRegistroViewModel
    {
        [Required(ErrorMessage = "Ingresa el nombre")]
        [StringLength(100)]
        public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "Ingresa el procesador")]
        [StringLength(100)]
        public string Procesador { get; set; } = "";

        [Required(ErrorMessage = "Ingresa la RAM")]
        [StringLength(50)]
        public string Ram { get; set; } = "";

        [Required(ErrorMessage = "Ingresa la tarjeta gráfica")]
        [StringLength(100)]
        public string TarjetaGrafica { get; set; } = "";

        [Required(ErrorMessage = "Ingresa el almacenamiento")]
        [StringLength(100)]
        public string Almacenamiento { get; set; } = "";

        [Range(typeof(decimal), "0.01", "9999999999.99",
            ErrorMessage = "Ingresa un precio válido")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue,
            ErrorMessage = "La existencia no puede ser negativa")]
        public int Existencia { get; set; }

        [StringLength(250)]
        public string? Imagen { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Selecciona una marca")]
        public int IdMarca { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Selecciona una categoría")]
        public int IdCategoria { get; set; }

        public List<SelectListItem> Marcas { get; set; } = new();

        public List<SelectListItem> Categorias { get; set; } = new();
    }
}
