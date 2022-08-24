namespace SistemaVenda.Dominio.Entidades
{
    public class VendaProdutos //ENTIDADE FRUTO DO RELACIONAMENTO ENTRE AS ENTIDADES PRODUTO & VENDA
    {
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }
        public double Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }

        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}
