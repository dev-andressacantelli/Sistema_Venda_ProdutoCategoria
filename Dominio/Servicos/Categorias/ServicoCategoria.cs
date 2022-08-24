using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVenda.Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class ServicoCategoria : IServicoCategoria // CLASSE CONCRETA : IMPLEMENTA A INTERFACE 
    {

        IRepositorioCategoria RepositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
        {
            RepositorioCategoria = repositorioCategoria;
        }

        public void Cadastrar(Categoria categoria)
        {
            RepositorioCategoria.Create(categoria);
        }

        public Categoria CarregarRegistro(int id)
        {
            return RepositorioCategoria.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioCategoria.Delete(id);
        }

        public IEnumerable<Categoria> Listagem()
        {
          return  RepositorioCategoria.Read();
        }
    }
}

