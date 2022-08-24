using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;
using System.Diagnostics;

namespace SistemaVenda.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        
        /* CÓDIGO JÁ EXISTENTE NA CRIAÇÃO DO PROJETO
         
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }                                  */

        public IActionResult Index()
        {

            return View();

            /* PASSO 4 DELETE - Testando exclusão de dados:
            Categoria objCategoria = Repositorio.Categoria.Where(x => x.Codigo == 1).FirstOrDefault(); 
            Repositorio.Attach(objCategoria);
            Repositorio.Remove(objCategoria);
            Repositorio.SaveChanges();
            return View(); */

            /* PASSO 3 UPDATE - Testando alteração dos dados já inseridos nas linhas de baixo:
            Categoria objCategoria = Repositorio.Categoria.Where(x => x.Codigo == 1).FirstOrDefault();
            objCategoria.Descricao = "Bebidas";
            Repositorio.Entry(objCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Repositorio.SaveChanges();
            return View(); */

            /* PASSO 2 READ - Testando criação de uma lista de leitura após executar o código de baixo (inserindo 2 testes):
            IEnumerable<Categoria> lista = Repositorio.Categoria.ToList();
            return View(lista); */

            /* PASSO 1 CREATE - Testando Inserção de dado no DB:
            Categoria categoria = new Categoria()
            {
                Descricao = "Teste2"
            };

            Repositorio.Categoria.Add(categoria);
            Repositorio.SaveChanges();
            return View();            */
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
