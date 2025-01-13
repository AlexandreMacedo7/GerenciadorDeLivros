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
            try
            {
                if (ModelState.IsValid)
                {
                    _livroDao.Create(livro);
                    TempData["MensagemSucesso"] = "Livro cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Criar", livro);
            }
            catch(SystemException erro)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o livro: " + erro.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarLivro(LivroModel livro)
        {
            try{
                if (ModelState.IsValid)
                {
                    _livroDao.UpdateLivro(livro);
                    TempData["MensagemSucesso"] = "Livro atualizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", livro);

            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = "Erro ao editar o livro: " + erro.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult ExcluirLivro(int id) {
            _livroDao.DeleteLivro(id);
            return RedirectToAction("Index");
        }
    }
}
