using System.Collections.Generic;

//MÉTODOS PADRÃO PARA TODAS AS ENTIDADES DO SISTEMA

namespace Dominio.Repositorio
{
    public interface IRepositorio<TEntidade>
        where TEntidade : class
    {
        void Create(TEntidade Entity); //CRIA A ENTIDADE
        TEntidade Read(int id); //LÊ O REGISTRO DA ENTIDADE
        void Delete(int id); //EXCLUE O REGISTRO DESSA ENTIDADE
        IEnumerable<TEntidade> Read(); //RETORNA UMA LISTA DO <TIPODAENTIDADE> NOMEADA DE "Read()"
    }
}
