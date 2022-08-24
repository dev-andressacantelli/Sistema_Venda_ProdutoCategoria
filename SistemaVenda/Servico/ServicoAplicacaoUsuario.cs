using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using System.Linq;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario 
    {
        private readonly IServicoUsuario ServicoUsuario; 

        //Construtor que injeta a interface do serviço do domínio:
        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            ServicoUsuario = servicoUsuario;
        }

        public Usuario RetornarDadosUsuario(string email, string senha)
        {
            return ServicoUsuario.Listagem().Where(x => x.Email == email && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return ServicoUsuario.ValidarLogin(email, senha);
        }
    }
}
