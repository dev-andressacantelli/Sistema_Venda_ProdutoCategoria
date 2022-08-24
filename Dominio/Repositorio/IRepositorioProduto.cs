using SistemaVenda.Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorioProduto : IRepositorio<Produto>
    {
        new IEnumerable<Produto> Read();
    }
}
