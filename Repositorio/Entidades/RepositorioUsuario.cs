using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;
using Repositorio.Contexto;
using System.Linq;

//ESSA CLASSE UTILIZA A COMO HERANÇA A CLASSE REPOSITORIO PARA SUA BASE 

namespace Repositorio.Entidades
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        //ApplicationDbContext HERDA de DbContext, portanto não é mais necessário chamar o próprio DbContext
        public RepositorioUsuario(ApplicationDbContext dbContext) : base(dbContext) { }

        public bool ValidarLogin(string email, string senha) //Validação se login do usuário tem acesso ou não
        {
            var usuario = DbSetContext.Where(x => x.Email == email && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault();
            return (usuario == null) ? false : true;
        }
    }
}
