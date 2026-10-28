using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCHIAPAS.Data;
using PCHIAPAS.Models;

namespace PCHIAPAS.Controllers
{
    public class ProductosController : Controller
    {
        private readonly PchiapasContext _context;

        public ProductosController(PchiapasContext context)
        {
            _context = context;
        }

        // Mostrar catálogo
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos
                .AsNoTracking()
                .OrderBy(p => p.IdProducto)
                .ToListAsync();

            return View(productos);
        }

        // Mostrar formulario
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var modelo = new ProductoRegistroViewModel();

            await CargarListas(modelo);

            return View(modelo);
        }

        // Guardar producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(
            ProductoRegistroViewModel modelo)
        {
            if (modelo.IdMarca > 0 &&
                !await _context.Marcas.AnyAsync(
                    m => m.IdMarca == modelo.IdMarca))
            {
                ModelState.AddModelError(
                    nameof(modelo.IdMarca),
                    "La marca no existe");
            }

            if (modelo.IdCategoria > 0 &&
                !await _context.Categorias.AnyAsync(
                    c => c.IdCategoria == modelo.IdCategoria))
            {
                ModelState.AddModelError(
                    nameof(modelo.IdCategoria),
                    "La categoría no existe");
            }

            if (!ModelState.IsValid)
            {
                await CargarListas(modelo);
                return View(modelo);
            }

            var producto = new Producto
            {
                Nombre = modelo.Nombre.Trim(),
                Procesador = modelo.Procesador.Trim(),
                Ram = modelo.Ram.Trim(),
                TarjetaGrafica = modelo.TarjetaGrafica.Trim(),
                Almacenamiento = modelo.Almacenamiento.Trim(),
                Precio = modelo.Precio,
                Existencia = modelo.Existencia,
                Imagen = string.IsNullOrWhiteSpace(modelo.Imagen)
                    ? null : modelo.Imagen.Trim(),
                IdMarca = modelo.IdMarca,
                IdCategoria = modelo.IdCategoria
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            TempData["Mensaje"] = "Producto registrado correctamente";

            return RedirectToAction("Index", "Inventario");
        }

        // Cargar marcas y categorías
        private async Task CargarListas(
            ProductoRegistroViewModel modelo)
        {
            var marcas = await _context.Marcas
                .AsNoTracking()
                .OrderBy(m => m.Nombre)
                .ToListAsync();

            modelo.Marcas = marcas.Select(m => new SelectListItem
            {
                Value = m.IdMarca.ToString(),
                Text = m.Nombre
            }).ToList();

            var categorias = await _context.Categorias
                .AsNoTracking()
                .OrderBy(c => c.Nombre)
                .ToListAsync();

            modelo.Categorias = categorias.Select(c => new SelectListItem
            {
                Value = c.IdCategoria.ToString(),
                Text = c.Nombre
            }).ToList();
        }
    }
}

