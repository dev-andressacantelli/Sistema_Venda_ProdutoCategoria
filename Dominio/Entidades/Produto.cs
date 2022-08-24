using Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVenda.Dominio.Entidades
{
    public class Produto : EntityBase
    {
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public decimal Valor { get; set; }


        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; } 
        /* Por padrão o entity não injeta, não inclui esse obj (Categoria) nas suas consultas,
        portanto, será necesário instancia-lo na RepositorioProduto através do método Read reescrito (override) */

        public ICollection<VendaProdutos> Vendas { get; set; }
    }
}

/* NO SQL SERVER:

FK_CodigoCategoria_Produto

Tabela de chave primária:
De qual tabela essa coluna está vindo = CATEGORIA/CODIGO

Tabela de chave estrangeira:
Para qual tabela essa coluna vai? = TABLE_ATUAL/CODIGOCATEGORIA */
