using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class VendaViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage="Informe a data da venda!")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessage = "Informe o cliente!")]
        public int? CodigoCliente { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }

        /* Esse obj JSON significa:
        Quando estiver na tela "cadastro de vendas" e enviar os dados p/ controller cadastrar vendas,
        será enviado um JSON que conterá os produtos que foram adicionados no formulário,
        para poder conseguir de certa forma pegar esses dados e gravar na tabela "VENDAPRODUTOS".
        Quando for registrar uma venda, além de criar um registro na TABELAVENDA,
        certamente será criado pelo menos UM registro (um ou +). */
        public string JsonProdutos { get; set; }
        public decimal Total { get; set; }
    }
}
