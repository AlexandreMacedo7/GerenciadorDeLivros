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
            List<LivroModel> livros = _livroDao.getAll();
            return View(livros);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            LivroModel livro = _livroDao.GetById(id);
            return View(livro);
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

        [HttpPost]
        public IActionResult EditarLivro(LivroModel livro)
        {
            _livroDao.UpdateLivro(livro);
            return RedirectToAction("Index");
        }
    }
}
