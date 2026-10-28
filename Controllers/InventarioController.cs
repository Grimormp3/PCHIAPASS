using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCHIAPAS.Data;

namespace PCHIAPAS.Controllers
{
    public class InventarioController : Controller
    {
        private readonly PchiapasContext _context;

        public InventarioController(PchiapasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos
                .AsNoTracking()
                .OrderBy(p => p.IdProducto)
                .ToListAsync();

            return View(productos);
        }
    }
}
