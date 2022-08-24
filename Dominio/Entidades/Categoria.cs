using Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaVenda.Dominio.Entidades
{
    public class Categoria : EntityBase
    {
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}

/* NO SQL SERVER:

FK_CodigoCategoria_Produto

Tabela de chave primária:
De qual tabela essa coluna está vindo = CATEGORIA/CODIGO

Tabela de chave estrangeira:
Para qual tabela essa coluna vai? = TABLE_ATUAL/CODIGOCATEGORIA */

