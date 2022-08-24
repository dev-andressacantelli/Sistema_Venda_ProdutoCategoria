using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Aplicacao.Servico;
using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Dominio.Repositorio;
using Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Dominio.Servicos;
using Repositorio.Contexto;

namespace SistemaVenda
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false; //DEIXAR FALSE SEMPRE
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /* Informando ao DbContext que ele irá usar o DB SQL Server:
            ConectionString completa foi movida p/ appsetings.json, aqui estamos apenas chamando-a.
            POR HORA, enquanto o projeto não é migrado definitivamente para DDD. */
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")));


            services.AddHttpContextAccessor();
            services.AddSession();


            //Adicionando escopo p/ leitura da camada de SERVIÇO APLICAÇÃO
            services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();
            services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();
            services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();
            services.AddScoped<IServicoAplicacaoVenda, ServicoAplicacaoVenda>();
            services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();

            /* Adicionando escopo p/ leitura da camada de DOMAIN
           (também precisa adicionar domain como referência) */
            services.AddScoped<IServicoCategoria, ServicoCategoria>();
            services.AddScoped<IServicoCliente, ServicoCliente>();
            services.AddScoped<IServicoProduto, ServicoProduto>();
            services.AddScoped<IServicoVenda, ServicoVenda>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();

            //Adicionando escopo p/ leitura da camada de REPOSITORIOCATEGORIA
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();
            services.AddScoped<IRepositorioVenda, RepositorioVenda>();
            services.AddScoped<IRepositorioVendaProdutos, RepositorioVendaProdutos>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


            services.AddControllersWithViews();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); DESABILITADO
        }

        /* Esse método CONFIGURE é chamado em tempo de execução e é utilizado para configurar o REQUEST pipeline HTTP. 
        Ou seja, quando realizamos uma requisição HTTP para a aplicação, em tempo de execução o método CONFIGURE é chamado.
        Para poder hospedar o projeto em algum servidor, seja AWS,Azure etc, 
        será necessário ter a variáveis de ambiente (localizada na barra principal de cima):
        Projeto > Propriedades de SistemaVenda > Depurar > Variáveis de ambiente 
        Umas das variáveis de ambiente, é a ASPNETCORE_ENVIRONMENT com valor Development 
        (ambiente de DSV que já vem chumbada no projeto);
        Teremos outras 2 possibilidades em valor: Production(ambiente de PRD) ou Staging(ambiente de HMG) */
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseExceptionHandler("/Error"); DESABILITADO

                app.UseHsts();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseRouting();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
