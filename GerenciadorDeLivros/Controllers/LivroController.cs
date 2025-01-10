using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ExcluirConfirmacao()
        {
            return View();
        }
    }
}
