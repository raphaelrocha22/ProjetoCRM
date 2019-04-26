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
    [RoutePrefix("api/instituicao")]
    public class InstituicaoController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public IHttpActionResult Cadastrar(InstituicaoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Instituicao i = new ModelConvertToEntity().ConverterInstituicao(model);
                    i.Usuario = new Usuario(); //TODO - apagar dps de implementar validacao
                    i.Id = Id.NewId(); //TODO - receber da camada de apresentacao (se nao gravado pelo app, gravar)
                    i.Endereco.Id = Id.NewId(); //TODO - receber da camada de apresentacao (se nao gravado pelo app, gravar)

                    new InstituicaoDAL().Cadastrar(i);
                    if (i.Funcionario != null)
                    {
                        try
                        {
                            new FuncionarioDAL().Cadastrar(i.Funcionario, i.Id);
                        }
                        catch (Exception e)
                        {
                            return StatusCode(HttpStatusCode.Accepted);
                        }
                    }
                    return Ok(i);
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        [Route("editar")]
        public IHttpActionResult Editar(InstituicaoViewModel model)
        {
            try
            {
                if (!Id.IsEmpty(model.Id))
                {
                    if (ModelState.IsValid)
                    {
                        Instituicao i = new ModelConvertToEntity().ConverterInstituicao(model);
                        i.Usuario = new Usuario(); //TODO - apagar dps de implementar validacao
                        new InstituicaoDAL().Editar(i);
                        return Ok(i);
                    }
                }
                else
                {
                    ModelState.AddModelError("Id", "Id Inválido");
                }
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        [Route("deletar")]
        public IHttpActionResult Deletar(long id)
        {
            try
            {
                if (!Id.IsEmpty(id))
                {
                    new InstituicaoDAL().Deletar(id);
                    return Ok(id);
                }
                return BadRequest("idInstituição inválido");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar(ConsultaInstituicaoViewModel model)
        {
            try
            {
                var lista = new InstituicaoDAL().Consultar();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
