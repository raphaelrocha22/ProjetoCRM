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
    [RoutePrefix("api/concorrencia")]
    public class ConcorrenciaController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public IHttpActionResult Cadastrar(ConcorrenciaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.TipoString = string.Empty;
                    var objetivo = model.Tipo.OrderBy(l => l.ToString()).ToList();
                    foreach (var item in objetivo)
                    {
                        if (!string.IsNullOrEmpty(model.TipoString))
                            model.TipoString += "|";

                        model.TipoString += item;
                    }
                    var c = new ModelConvertToEntity().ConverterConcorrencia(model);
                    c.Id = Id.NewId();
                    new ConcorrenciaDAL().Cadastrar(c);
                    return Ok(model);
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
        public IHttpActionResult Editar(ConcorrenciaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (new ConcorrenciaDAL().IsUsuarioHabilitado(model.Id, model.Usuario.Id))
                    {
                        model.TipoString = string.Empty;
                        var objetivo = model.Tipo.OrderBy(l => l.ToString()).ToList();
                        foreach (var item in objetivo)
                        {
                            if (!string.IsNullOrEmpty(model.TipoString))
                                model.TipoString += "|";

                            model.TipoString += item;
                        }
                        var c = new ModelConvertToEntity().ConverterConcorrencia(model);
                        new ConcorrenciaDAL().Editar(c);
                        return Ok(model);
                    }
                    return BadRequest("A edição está habilitada apenas para o usuário que realizou este cadastro");
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
