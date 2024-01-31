using Microsoft.AspNetCore.Mvc;
using PriSistema.Interfaces.Repository;
using PriSistema.Models;

namespace PriSistema.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.BuscasTodos();
            return View(contatos);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepository.BuscasPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepository.BuscasPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepository.ApagarPorId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Novo(ContatoModel contato)
        {
            if(ModelState.IsValid)
            {
                _contatoRepository.Adicionar(contato);
                return RedirectToAction("Index");
            }
            
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepository.Alterar(contato);
                return RedirectToAction("Index");
            }

            return View("Editar", contato);
        }
    }
}
