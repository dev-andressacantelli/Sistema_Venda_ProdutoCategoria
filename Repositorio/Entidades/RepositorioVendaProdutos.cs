using Dominio.Repositorio;
using Repositorio.Contexto;
using SistemaVenda.Dominio.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioVendaProdutos : IRepositorioVendaProdutos
    {
        protected ApplicationDbContext DbSetContext;

        //O ApplicationDbContext não é estático, então pecisa de uma instância, portanto será necessário criar um construtor:
        public RepositorioVendaProdutos(ApplicationDbContext mContext)
        {
            DbSetContext = mContext;
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            var lista = (from r in DbSetContext.VendaProdutos
                         group r by new { r.CodigoProduto, r.Produto.Descricao }
                         into g
                         select new GraficoViewModel
                         {
                             CodigoProduto = g.Key.CodigoProduto,
                             Descricao = g.Key.Descricao,
                             TotalVendido = g.Sum(x => x.Quantidade)

                         }).ToList();
            return lista;
        }
    }
}

/* CODIGO PROPOSTO NÃO RODA NESSA VERSÃO DE EFCORE:

var lista = DbSetContext.VendaProdutos.Include(x => x.Produto)
.GroupBy(x => x.CodigoProduto)
.Select(y => new GraficoViewModel
{
    CodigoProduto = y.First().CodigoProduto,
    Descricao = y.First().Produto.Descricao,
    TotalVendido = y.Sum(z => z.Quantidade)
}).ToList();

return lista; 

*/