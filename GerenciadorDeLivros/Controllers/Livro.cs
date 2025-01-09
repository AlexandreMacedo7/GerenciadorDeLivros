using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers
{
    public class Livro : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
