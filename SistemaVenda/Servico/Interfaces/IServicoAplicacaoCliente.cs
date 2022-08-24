using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;
using System.Collections.Generic;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        IEnumerable<SelectListItem> ListaClientesDropDownList();
        IEnumerable<ClienteViewModel> Listagem();

        ClienteViewModel CarregarRegistro(int codigoCliente);

        void Cadastrar(ClienteViewModel cliente);

        void Excluir(int id);
    }
}
