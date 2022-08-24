using Dominio.Interfaces;
using Dominio.Repositorio;
using SistemaVenda.Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario // CLASSE CONCRETA : IMPLEMENTA A INTERFACE 
    {

        IRepositorioUsuario RepositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }

        public void Cadastrar(Usuario usuario)
        {
            RepositorioUsuario.Create(usuario);
        }

        public Usuario CarregarRegistro(int id)
        {
            return RepositorioUsuario.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioUsuario.Delete(id);
        }

        public IEnumerable<Usuario> Listagem()
        {
          return  RepositorioUsuario.Read();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return RepositorioUsuario.ValidarLogin(email, senha);
        }
    }
}

