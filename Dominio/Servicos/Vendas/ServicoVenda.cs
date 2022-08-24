using Dominio.Interfaces;
using Dominio.Repositorio;
using System.Collections.Generic;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Dominio.DTO;

namespace Dominio.Servicos
{
    public class ServicoVenda : IServicoVenda
    {
        IRepositorioVenda RepositorioVenda;
        IRepositorioVendaProdutos RepositorioVendaProdutos;

        public ServicoVenda(
            IRepositorioVenda repositorioVenda,
            IRepositorioVendaProdutos repositorioVendaProdutos)
        {
            RepositorioVenda = repositorioVenda;
            RepositorioVendaProdutos = repositorioVendaProdutos;

        }

        public void Cadastrar(Venda venda)
        {
            RepositorioVenda.Create(venda);
        }

        public Venda CarregarRegistro(int id)
        {
            return RepositorioVenda.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioVenda.Delete(id);
        }

        public IEnumerable<Venda> Listagem()
        {
            return RepositorioVenda.Read();
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            return RepositorioVendaProdutos.ListaGrafico();
        }
    }
}

