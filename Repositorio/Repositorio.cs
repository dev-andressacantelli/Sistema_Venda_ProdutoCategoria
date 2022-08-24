using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

/* CLASSE ABSTRATA:
Base/modelo para produzir novas classes, 
utiliza-se essa classe para HERDAR seu conteúdo e MELHORAR a especificação de uma classe.
As classe abstratas não geram objetos, não é possível criar instância dessa classe (new).

COMO FUNCIONA ESSA CLASSE:
Repositorio espera receber uma <TIPOENTIDADE> HERDA da classe DbContext e IMPLEMENTA a interface IRepositorio<TIPOENTIDADE>

CONSTRUTOR: 
Cria-se o contexto de banco de dados (DbContext)
seta a entidade para o Db.Set p/ poder conseguir usar a entidade para os demais métodos. */

namespace Repositorio
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade>
        where TEntidade : EntityBase, new() //ÚNICO NEW POSSÍVEL, já instanciando uma única vez (contado à partir deste momento, zerado a partir daqui)
    {
        //CONSTRUTOR:
        protected DbContext Db;
        protected DbSet<TEntidade> DbSetContext; //Protected: Uma classe que herdar desta, pode fazer uso daquilo que foi protegido;

        public Repositorio(DbContext dbContext)
        {
            Db = dbContext;
            DbSetContext = Db.Set<TEntidade>();
        }


        public void Create(TEntidade Entity)
        {
            if (Entity.Codigo == null)
            {
                DbSetContext.Add(Entity);
            }
            else
            {
                Db.Entry(Entity).State = EntityState.Modified;
            }
             
            Db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var ent = new TEntidade { Codigo = id };
            DbSetContext.Attach(ent);
            DbSetContext.Remove(ent);
            Db.SaveChanges();
        }

        public TEntidade Read(int id)
        {
            return DbSetContext.Where(x => x.Codigo == id).FirstOrDefault();
        }

        //Esse método está sendo reescrito na classe RepositorioProduto
        public virtual IEnumerable<TEntidade> Read()
        {
            return DbSetContext.AsNoTracking().ToList();
        }
    }
}




/* AsNoTracking:
Toda vez que o sistema requisita informações do banco de dados via Entity Framework, 
o ORM mantém na memória objetos adicionais a fim de manter a rastreabilidade (tracking) 
de mudanças nos objetos resgatados da base de dados, 
a fim de saber se um comando “UPDATE” precisa realmente ser executado caso o método “SaveChanges” seja chamado.
Este é o comportamento padrão do Entity Framework e, num primeiro momento, não há problema nenhum com isso. 
Isso otimiza operações de atualizações de informações na base dados. 
Mas, e nas situações que não precisamos atualizar os registros na base de dados após uma operação de “Select”? 
Por que manter objetos adicionais na memória se não vamos utilizá-los?
Então, caso em rotinas do sistema que você está desenvolvendo existam operações apenas “readonly”, 
recomendo que utilize o método AsNoTracking, pois isso irá representar, além de ganho de performance, 
uma otimização de utilização de recursos de servidor, 
o que pode ser crucial em sistemas com grande quantidade de acessos simultâneos. */





