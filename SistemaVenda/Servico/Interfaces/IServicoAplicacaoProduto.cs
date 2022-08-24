using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<SelectListItem> ListaProdutosDropDownList();
        IEnumerable<ProdutoViewModel> Listagem();

        ProdutoViewModel CarregarRegistro(int codigoProduto);

        void Cadastrar(ProdutoViewModel produto);

        void Excluir(int id);
    }
}
