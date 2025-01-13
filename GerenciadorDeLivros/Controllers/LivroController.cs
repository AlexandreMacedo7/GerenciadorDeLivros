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
        public IActionResult ExcluirConfirmacao(int id)
        {
            LivroModel livro = _livroDao.GetById(id);
            return View(livro);
        }

        [HttpPost]
        public IActionResult CriarLivro(LivroModel livro)
        {
            if (ModelState.IsValid)
            {
                _livroDao.Create(livro);
                return RedirectToAction("Index");
            }
            return View("Criar",livro);
        }

        [HttpPost]
        public IActionResult EditarLivro(LivroModel livro)
        {
            if(ModelState.IsValid)
            {
                _livroDao.UpdateLivro(livro);
                return RedirectToAction("Index");
            }
            return View("Editar",livro);
        }

        public IActionResult ExcluirLivro(int id) {
            _livroDao.DeleteLivro(id);
            return RedirectToAction("Index");
        }
    }
}
