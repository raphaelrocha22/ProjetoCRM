using Projeto.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Servico.Models
{
    //Serve tanto para Cadastro como Edicao
    public class ConcorrenciaViewModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public Empresa Empresa { get; set; }
        public List<TipoConcorrencia> Tipo { get; set; }
        public string TipoString { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}