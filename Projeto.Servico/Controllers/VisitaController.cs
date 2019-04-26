using Microsoft.AspNet.Identity;
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
    [RoutePrefix("api/visita")]
    public class VisitaController : ApiController
    {
        [HttpPost]
        [Route("cadastrar")]
        public IHttpActionResult Cadastrar(CadastroVisitaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Descricao.ObjetivoString = string.Empty;
                    var objetivo = model.Descricao.Objetivo.OrderBy(l => l.ToString()).ToList();
                    foreach (var item in objetivo)
                    {
                        if (!string.IsNullOrEmpty(model.Descricao.ObjetivoString))
                            model.Descricao.ObjetivoString += "|";

                        model.Descricao.ObjetivoString += item;
                    }

                    var v = new ModelConvertToEntity().ConverterVisitaCadastro(model);
                    v.Id = Id.NewId();
                    new VisitaDAL().Cadastrar(v);
                    return Ok(v);
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
