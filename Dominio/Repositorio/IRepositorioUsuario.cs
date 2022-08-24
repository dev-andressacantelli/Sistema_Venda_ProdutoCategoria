using SistemaVenda.Dominio.Entidades;

namespace Dominio.Repositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        bool ValidarLogin(string email, string senha);
    }
}
