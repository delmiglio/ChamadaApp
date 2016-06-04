using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.VO;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [ActionName("Autenticar")]
        public HttpResponseMessage PostUsuarioAutenticacao([FromBody] UsuarioVO usuario)
        {
            Retorno obj = new Retorno();

            if (string.IsNullOrWhiteSpace(usuario.Token) && !usuario.Ativo)
            {
                //Verifica se os parametros foram informados.
                if (string.IsNullOrWhiteSpace(usuario.Login) || string.IsNullOrWhiteSpace(usuario.Senha))
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Erro;
                    obj.RetornoMensagem = "Login Inválido!";
                    obj.RetornoDescricao = "Para efetuar o login, deverá ser informado os campos Login e Senha.";
                }
                else
                {
                    UsuarioVO user = LoginDAO.GetUserAutenticacao(usuario.Login, usuario.Senha);

                    if (user == null)
                    {
                        obj.TpRetorno = (int)TpRetornoEnum.SemRetorno;
                        obj.RetornoMensagem = "Login Inválido!";
                        obj.RetornoDescricao = "Verifique se as credenciais estão corretas!";
                    }
                    else
                    {
                        user.Token = Guid.NewGuid().ToString();
                        user.Ativo = true;

                        obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                        obj.ObjRetorno = user;
                        obj.ObjTypeName = user.GetType().Name;
                    }
                }
            }
            else
            {
                usuario.DtAlteracao = DateTime.Now.ToShortDateString();

                LoginDAO.Autenticar(usuario);

                obj.TpRetorno = (int)TpRetornoEnum.Sucesso;                                
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPost]
        [ActionName("ValidaAcesso")]
        public HttpResponseMessage PostValidaAcesso([FromBody] UsuarioVO usuario)
        {
            Retorno obj = new Retorno(); 
            
            if(usuario.Id == 0 || string.IsNullOrWhiteSpace(usuario.Login) || string.IsNullOrWhiteSpace(usuario.Senha) || string.IsNullOrWhiteSpace(usuario.Token))
            {
                obj.TpRetorno = (int)TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Acesso Inválido";
                obj.RetornoDescricao = "Compareça a secretaria da instituição para verificar o ocorrido.";
            }
            else
            {
                bool resposta = LoginDAO.ValidaAcesso(usuario);

                if (resposta)
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                    obj.RetornoMensagem = "Acesso Valido";
                }
                else
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Erro;
                    obj.RetornoMensagem = "Acesso Inválido";
                    obj.RetornoDescricao = "Compareça a secretaria da instituição para verificar o ocorrido.";
                }
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
