using SistemaVenda.Dominio.Entidades;
using Dominio.Repositorio;
using Repositorio.Contexto;

//ESSA CLASSE UTILIZA A COMO HERANÇA A CLASSE REPOSITORIO PARA SUA BASE 

namespace Repositorio.Entidades
{
    public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        //ApplicationDbContext HERDA de DbContext, portanto não é mais necessário chamar o próprio DbContext
        public RepositorioCategoria(ApplicationDbContext dbContext) : base(dbContext) { } 
    }
}
