using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria //ESSA CLASSE FAZ O PEDIDO DA APLICAÇÃO P/ O DOMINIO
    {
        private readonly IServicoCategoria ServicoCategoria; //Injeção de dependencia

        //Construtor que injeta a interface do serviço do domínio:
        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
        {
            ServicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            Categoria item = new Categoria()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            ServicoCategoria.Cadastrar(item);
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
            var registro = ServicoCategoria.CarregarRegistro(codigoCategoria);

            CategoriaViewModel categoria = new CategoriaViewModel()
            {
                Codigo = registro.Codigo,
                Descricao = registro.Descricao
            };

            return categoria;
        }

        public void Excluir(int id)
        {
            ServicoCategoria.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaCategoriasDropDownList()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                SelectListItem categoria = new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(categoria);
            }

            return retorno;
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            //MAPEANDO A LISTA
            var lista = ServicoCategoria.Listagem();
            List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();
            
            foreach (var item in lista) 
            {
                CategoriaViewModel categoria = new CategoriaViewModel()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };

                listaCategoria.Add(categoria);
            }

            return listaCategoria;
        }
    }
}
