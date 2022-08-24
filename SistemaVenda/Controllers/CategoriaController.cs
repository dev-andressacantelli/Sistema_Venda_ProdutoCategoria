using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {
        readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;


        //CONSTRUTOR
        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria; //INJEÇÃO DE DEPENDENCIA
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoCategoria.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id) //Pode receber nulo (pode não ter esse parâmetro, funcionará normalmente)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if (id != null)
            {
                viewModel = ServicoAplicacaoCategoria.CarregarRegistro((int)id);
            }

            return View(viewModel);
        }

        [HttpPost] //Validação pra MODEL
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCategoria.Cadastrar(entidade);   
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoCategoria.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}

