using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Newtonsoft.Json;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda ServicoVenda; //Injeção de dependencia

        //Construtor que injeta a interface do serviço do domínio:
        public ServicoAplicacaoVenda(IServicoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel venda)
        {
            Venda item = new Venda()
            {
                Codigo = venda.Codigo,
                Data = (DateTime)venda.Data,
                CodigoCliente = (int)venda.CodigoCliente,
                Total = venda.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(venda.JsonProdutos)
                /* AQUI em PRODUTOS ENTRA O JSON PRODUTOS (ViewModel)
                Produtos é do tipo ICollections e ProdutosJSON é string, portanto será necessário DESERIALIZAR:
                Quando DESEREALIZA um JSON, pega a STRING e coloca em forma de ICollections. */
            };

            ServicoVenda.Cadastrar(item);
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
            var registro = ServicoVenda.CarregarRegistro(codigoVenda);

            VendaViewModel venda = new VendaViewModel()
            {
                Codigo = registro.Codigo,
                Data = (DateTime)registro.Data,
                CodigoCliente = (int)registro.CodigoCliente,
                Total = registro.Total
            };

            return venda;
        }

        public void Excluir(int id)
        {
            ServicoVenda.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            var lista = ServicoVenda.Listagem();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();

            foreach (var item in lista)
            {
                VendaViewModel venda = new VendaViewModel()
                {
                    Codigo = item.Codigo,
                    Data = (DateTime)item.Data,
                    CodigoCliente = (int)item.CodigoCliente,
                    Total = item.Total
                };

                listaVenda.Add(venda);
            }

            return listaVenda;
        }

        //Criando mapeamento pois não é possível converter o tipo de arquivo de DTO em <model>
        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            List<GraficoViewModel> lista = new List<GraficoViewModel>();

            var auxLista = ServicoVenda.ListaGrafico();

            foreach (var item in auxLista)
            {
                GraficoViewModel grafico = new GraficoViewModel()
                {
                    CodigoProduto = item.CodigoProduto,
                    Descricao = item.Descricao,
                    TotalVendido = item.TotalVendido
                };

                lista.Add(grafico);
            }

            return lista;
        }
    }
}

