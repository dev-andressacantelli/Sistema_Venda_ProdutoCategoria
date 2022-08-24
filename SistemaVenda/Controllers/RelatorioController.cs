using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        readonly IServicoAplicacaoVenda ServicoVenda;

        public RelatorioController(IServicoAplicacaoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }

        public IActionResult Grafico()
        {
            var lista = ServicoVenda.ListaGrafico().ToList();

            string valores = string.Empty; //Recebe os valores dos produtos do campo "totalvendido" em formato: 22,4,12,... 
            string labels = string.Empty;  //Recebe os valores do campo "Descricao" em formato: coca,trakinas,finni,... 
            string cores = string.Empty;  //Recebe os valores das cores em formato: '#f0f0f0''c2c2c2'...

            var random = new Random(); //Variável p/ criação de cores aleatórias utilizado dentro do for

            //Percorrer a lista p/ obter um registro de um produto específico:
            for (int i = 0; i < lista.Count; i++)
            {
                valores += lista[i].TotalVendido.ToString() + ","; //essa " , " representa a mesma lógica de "valor," no array data: [24, 10, 7, 4, 21] (Grafico.cshtml)
                labels += "'" + lista[i].Descricao.ToString() + "',"; //essa " , " representa a mesma lógica de "descrição,"
                cores += "'" + String.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            }

            ViewBag.Valores = valores;
            ViewBag.Labels = labels;
            ViewBag.Cores = cores;

            return View();
        }
    }
}


/* ViewBag é apenas um invólucro dinâmico em torno de ViewData, 
sendo uma propriedade dinâmica baseada no recurso dynamic da plataforma .NET 
Com ViewBag você não precisa escrever a palavra-chave dynamic, 
ele usa a palavra-chave dynamic internamente.  
As viewBags aqui são os ajustes para utilizar na view todo esse código gerado aqui na controller. */

/* Codigo proposto que não roda nessa versão do EFCore:
var lista = mContext.VendaProdutos
    .GroupBy(x => x.CodigoProduto)
    .Select(y => new GraficoViewModel //Instanciando o gráfico uma únic vez
    {
        CodigoProduto = y.First().CodigoProduto,
        Descricao = y.First().Produto.Descricao,
        TotalVendido = y.Sum(z => z.Quantidade)

    }).ToList(); */

/* Realizando um SELECT dentro dos dados: CodigoProduto, Descrição e Quantidade,
jogando para dentro de uma instância do tipo GraficoViewModel, criado uma lista com "ToList".
É utilizado o first p/ agregar o sum mais abaixo! 

Esse trecho de código, seria o mesmo que executar a query no DB:

SELECT SUM(v.quantidade) AS totalvendido, codigoproduto, p.Descricao
FROM VendaProdutos v INNER JOIN Produto p
ON v.CodigoProduto = p.Codigo
GROUP BY codigoproduto, p.Descricao */



