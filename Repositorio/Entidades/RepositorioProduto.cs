using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext) { }

        /* Reescrevendo (override) o método BASE que está dentro da classe Repositorio, 
        pois quando o método for lido, ele será lido aqui e não em sua classe abstrata! */
        public override IEnumerable<Produto> Read()
        {
            return DbSetContext.Include(x => x.Categoria).AsNoTracking().ToList();//Incluindo categoria na consulta;
        }
    }
}
