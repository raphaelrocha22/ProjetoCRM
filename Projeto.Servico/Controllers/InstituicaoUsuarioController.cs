using Projeto.DAL.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Servico.Controllers
{
    [Authorize]
    [RoutePrefix("api/instituicaoUsuario")]
    public class InstituicaoUsuarioController : ApiController
    {
        [HttpPost]
        [Route("cadastrarRelacionamento")]
        public IHttpActionResult CadastrarRelacionamento(int idUsuario, long idInstituicao, string nomeInstituicao)
        {
            try
            {
                new InstituicaoUsuarioDAL().Cadastrar(idUsuario, idInstituicao, nomeInstituicao);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [Route("deletarRelacionamento")]
        public IHttpActionResult DeletarRelacionamento(int idUsuario, long idInstituicao)
        {
            try
            {
                new InstituicaoUsuarioDAL().Deletar(idUsuario, idInstituicao);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
