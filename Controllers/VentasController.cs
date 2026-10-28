using Microsoft.AspNetCore.Mvc;

namespace PCHIAPAS.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
