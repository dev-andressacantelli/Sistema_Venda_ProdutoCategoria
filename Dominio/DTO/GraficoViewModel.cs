namespace SistemaVenda.Dominio.DTO
{
    public class GraficoViewModel
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public double TotalVendido { get; set; }
    }
}

//O DTO é apenas um objeto de transferencia para que não seja usado a classe principal, por motivos de segurança.
