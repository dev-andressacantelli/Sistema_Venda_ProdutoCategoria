using SistemaVenda.Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorioVenda : IRepositorio<Venda>
    {
        new void Delete(int id);
    }
}
