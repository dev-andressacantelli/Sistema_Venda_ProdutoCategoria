using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage="Informe a descrição do produto!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a quantidade em estoque do produto!")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o valor unitário do produto!")]
        [Range(0.1, double.PositiveInfinity)] //Range de valores positivos
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Informe a categoria do produto!")]
        public int? CodigoCategoria { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
        //<SelectListItem> é uma classe que ajuda renderizar determinados conteúdos na view (p/ poder popular DropDownList);

        public string DescricaoCategoria { get; set; }
    }
}
