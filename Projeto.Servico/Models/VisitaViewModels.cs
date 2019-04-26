using Projeto.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Servico.Models
{
    //Serve tanto para Cadastro como Edicao
    public class VisitaViewModel
    {
        public long Id { get; set; }

        public UsuarioViewModel Usuario { get; set; }

        public InstituicaoViewModel Instituicao { get; set; }

        public DateTime DataVisita { get; set; }

        public GeoLocalizacaoModel GeoLocalizacao { get; set; }

        public DescricaoVisitaModel Descricao { get; set; }

        public List<ConcorrenciaViewModel> Concorrencia { get; set; }
    }

    public class DescricaoVisitaModel
    {
        [Required(ErrorMessage = "Informe o objetivo da visita")]
        public List<Objetivo> Objetivo { get; set; }

        public string ObjetivoString { get; set; }

        [MaxLength(500, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Comente o que foi abordado na visita")]
        public string Comentario { get; set; }

        public List<FuncionarioViewModel> Funcionario { get; set; }

        public List<long> IdFuncionario { get; set; }
    }

    public class GeoLocalizacaoModel
    {
        [GeolocalizacaoValidator(ErrorMessage = "{0} inválida")]
        [Required(ErrorMessage = "{0}: Campo obrigatório")]
        public decimal Latitude { get; set; }

        [GeolocalizacaoValidator(ErrorMessage = "{0} inválida")]
        [Required(ErrorMessage = "{0}: Campo obrigatório")]
        public decimal Longitude { get; set; }
    }

    public class GeolocalizacaoValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (decimal)value != 0;
        }
    }
    
    //TODO - Tem necessidade ?
    public class CadastroVisitaViewModel
    {
        public long IdVisita { get; set; }
        public int IdUsuario { get; set; }
        public long IdInstituicao { get; set; }
        public List<long> IdConcorrencia { get; set; }
        public DateTime DataVisita { get; set; }

        public GeoLocalizacaoModel GeoLocalizacao { get; set; }

        public DescricaoVisitaModel Descricao { get; set; }
    }
}