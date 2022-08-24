using System.Collections.Generic;

//INTERFACE Genérica que define as operações básicas de uma tela, toda interface do sistema implementa essa!

namespace Dominio.Interfaces
{
    public interface IServicoCRUD<TEntidade>
        where TEntidade : class
    {
        IEnumerable<TEntidade> Listagem();
        void Cadastrar(TEntidade categoria);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);
    }
}
