using Projeto.DAL.Persistencia;
using Projeto.Entidade;
using Projeto.Servico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Servico.Controllers
{
    [Authorize]
    [RoutePrefix("api/funcionario")]
    public class FuncionarioController : ApiController
    {
        [HttpPost]
        [Route("cadastrarFuncionario")]
        public IHttpActionResult CadastrarFuncionario([FromUri]long idInstituicao, List<FuncionarioViewModel> model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lista = new List<Funcionario>();
                    foreach (var funcionario in model)
                    {
                        var f = new ModelConvertToEntity().ConverterFuncionario(funcionario);
                        f.Id = Id.NewId(); //TODO - receber da camada de apresentacao (se nao gravado pelo app, gravar)
                        lista.Add(f);
                    }

                    new FuncionarioDAL().Cadastrar(lista, idInstituicao);
                    return Ok(lista);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        [Route("cadastrarRelacionamento")]
        public IHttpActionResult CadastrarRelacionamento([FromUri]long idInstituicao, List<FuncionarioViewModel> model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lista = new List<Funcionario>();
                    foreach (var funcionario in model)
                    {
                        var f = new ModelConvertToEntity().ConverterFuncionario(funcionario);
                        lista.Add(f);
                    }

                    new FuncionarioDAL().CadastrarRelacionamento(lista,idInstituicao);
                    return Ok(lista);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
