using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<SelectListItem> ListaCategoriasDropDownList();
        IEnumerable<CategoriaViewModel> Listagem();

        CategoriaViewModel CarregarRegistro(int codigoCategoria);

        void Cadastrar(CategoriaViewModel categoria);

        void Excluir(int id);
    }
}
