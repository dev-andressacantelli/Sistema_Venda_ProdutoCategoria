using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Helpers;
using SistemaVenda.Models;
using Microsoft.AspNetCore.Http;
using Aplicacao.Servico.Interfaces;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        protected IHttpContextAccessor HttpContextAccessor;
        readonly IServicoAplicacaoUsuario ServicoAplicacaoUsuario;

        public LoginController(IServicoAplicacaoUsuario servicoAplicacaoUsuario, IHttpContextAccessor httpContext)
        {
            ServicoAplicacaoUsuario = servicoAplicacaoUsuario; //INJEÇÃO DE DEPENDENCIA
            HttpContextAccessor = httpContext;
        }

        //Redirecionando p/ outra página quando o usuário solicitar LogOff
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContextAccessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty; //COMEÇA VAZIO, MAS SE ERRAR A SENHA, ENTRA NO BLOCO USUARIO == NULL

            if (ModelState.IsValid)
            {
                var Senha = Criptografia.GetMd5Hash(model.Senha); //Conversão da string senha p/ MD5 (função hash criptográfica)

                bool login = ServicoAplicacaoUsuario.ValidarLogin(model.Email, Senha);
                var usuario = ServicoAplicacaoUsuario.RetornarDadosUsuario(model.Email, Senha);

                if (login)
                {
                    //Colocar os dados do usuário na sessão
                    HttpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    HttpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ErroLogin"] = "O email ou senha informado não existe no sistema!"; //SE DE FATO O USUÁRIO ERROU A SENHA, ENTRARÁ NESSE BLOCO
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}