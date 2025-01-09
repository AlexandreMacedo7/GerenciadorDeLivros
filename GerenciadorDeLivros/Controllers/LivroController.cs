using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
