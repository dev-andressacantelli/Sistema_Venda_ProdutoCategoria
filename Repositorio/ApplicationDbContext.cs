using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;

namespace Repositorio.Contexto
{
    /* Essa classe de contexto administra os objetos entidades durante o tempo de execução, 
    o que inclui preencher objetos com dados de um banco de dados, controlar alterações, 
    e persistir dados para o banco de dados. */
    public class ApplicationDbContext : DbContext //Intermédio com o banco de dados
    {                
        //Dentro da <> sempre terá uma ENTIDADE
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        /*Construtor que recebe as configurações do ApplicationDbContext
        recebe o obj otpions e o construtor padrão recebe as configurações e aplica; */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //Declarando as chaves primarias da tabela(entidade) "VendaProdutos"
            builder.Entity<VendaProdutos>().HasKey(x => new { x.CodigoVenda, x.CodigoProduto });

            builder.Entity<VendaProdutos>()
                .HasOne(x => x.Venda) //A entidade "VendaProdutos" tem uma venda 
                .WithMany(y => y.Produtos) //com muitos produtos
                .HasForeignKey(x => x.CodigoVenda); //e tem a chave estrangeira "CodigoVenda"

            //Tratar o produto
            builder.Entity<VendaProdutos>()
               .HasOne(x => x.Produto) //A entidade "VendaProdutos" tem um produto "coca-cola" 
               .WithMany(y => y.Vendas) //com muitas vendas
               .HasForeignKey(x => x.CodigoProduto); //e tem a chave estrangeira "CodigoProduto"
        }
    }
}
