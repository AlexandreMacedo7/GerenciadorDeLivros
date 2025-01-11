using GerenciadorDeLivros.Daos;
using GerenciadorDeLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivros.Controllers
{

    public class LivroController : Controller
    {

        private readonly LivroDao _livroDao;

        public LivroController(LivroDao livroDao)
        {
            _livroDao = livroDao;
        }

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

        [HttpPost]
        public IActionResult CriarLivro(LivroModel livro)
        {
            _livroDao.Create(livro);
            return RedirectToAction("Index");
        }
    }
}
