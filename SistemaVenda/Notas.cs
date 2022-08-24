namespace SistemaVenda
{
    public class Notas
    { /*
       * Interfaces:
       Priorizar injetar a interface invés da classe concreta, 
       pois quando injetamos uma interface no construtor de uma classe, o que chega é o obj concreto, 
       mas não estaremos amarrados à classe em si. Significa que se eu tenho uma Interface, 
       possuiriei mais facilidade na manutenção do meu sistema,
       pois o conceito de uma Interface em POO é criar um contrato de implementação. 

       * Injeção de dependência:
       Passa como parâmetro p/ dentro do construtor de um recurso a interface daquele recurso que está injetando, 
       e assim terá acesso às funcionalidades dele.

        Ex:
        public Startup(Iconfiguration configuration)
        {
            Configuration = configuration;
        }

        Injetei Iconfiguration que me dá acesso às configurações da minha aplicação 

       Toda vez que uma aplicação ASP.net core vai rodar,
       ele passa primeiro na classe program e vai no método void Main e manda criar o HOST;

       Toda requisição que você faz, passará primeiro no construtor da CONTROLLER, se vc tiver o construtor;
       Refatoração:
       Rever classes, reescrever trechos que não ficaram legais, melhorar métodos.
       
       * Acoplamento e Coesão são conceitos que andam juntos!

       * Acoplamento: 
       O nível de ligações (dependências) que os elementos, componentes e recursos de software têm para uns com os outros.

        Ex: Classe Cliente
            Classe Venda
            Classe Venda_Produto
            Classe Produto
    
       O acoplamento está relacionado com as ligações que existem entre esses componentes.
       Sabendo que 1 Cliente pode ter N Vendas_Produto, será associado um acoplamento.	

        Ex: Quantas referências  classe possui?
        A classe ApplicationDbContext têm 17 referências.

        Ex: Em DB
        A classe Cliente possui 9 referências 
        e cada Atributo possui:

        7 ref de Codigo { get; set; }
        4 ref de Nome { get; set; }
        3 ref de CNPJ_CPF { get; set; }
        3 ref de Email { get; set; }
        3 ref de Celular { get; set; }
        0 ref de ICollection<Venda> Vendas { get; set; }

       * Coesão:
       Característica de fazer apenas o que tem haver com o objeto em questão.


       * Design Patterns
       ---- Padrão de projeto DDD - Domain Driven Design ----
                   (Design Dirigido ao Domínio)

        Camadas - O básico para se aplicar:

        - Usuário cria estimulos p/ dentro do sistema (cria requisições, pede informações para a aplicação);
        - Aplicação consome serviços da própria aplicação;
        - Serviços Aplicação conversa com o SERVIÇO DE DOMÍNIO 
        (ele não pode realizar acesso ao repositório, se não estaria crindo acoplamento);
        - Serviço de Domínio conversa diretamente com o repositório de forma desacoplada, 
        se quisermos cortar o repositório e colocar outro, é possível realizar sem interferir todo o projeto;
        - Se tiver uma camada de Mobile, conversaria com Serviços de Domínio sem interferir todo o projeto;
        - Se tiver uma camada de Web, também conversaria com Serviços de Domínio sem interferir todo o projeto;
        - Infraestrutura, serve para sustentar toda a estrutura do projetoe é acessada por todas as camadas
        (se a camada de repositório precisa de alguma coisa que é geral, coloca-se na camada de infra);


        BANCO DE DADOS:
        lucius-malfoy@outlook.com
        Senha:sonserina123 
        GEROU:775e9967a989e9febc8705786b08a312

        andressa-cantelli@outlook.com
        Senha:Senha@123 
        GEROU:23e4b3eb0ac3ae12d4f9e13372b49cda

        andressa.cantelli@crefisa.com.br
        Senha:Teste123 
        GEROU:06afa6c8b54d3cc80d269379d8b6a078

        celio-souza@crefisa.com
        Senha:celio123 
        GEROU:e68f6d4855eb1f591514ec8b85a359ae

        ROTAS:
        https://localhost:44391/Cliente/Index
        https://localhost:44391/Categoria/Index
        https://localhost:44391/Produto/Index
        https://localhost:44391/Venda/Index
        https://localhost:44391/Relatorio/Grafico

         */
    }
}
