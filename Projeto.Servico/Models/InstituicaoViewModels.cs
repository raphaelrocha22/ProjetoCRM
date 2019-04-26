using Projeto.Entidade;
using Projeto.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Servico.Models
{
    //Serve tanto para Cadastro como Edicao
    public class InstituicaoViewModel
    {
        public long Id { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        [MaxLength(50, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o nome da instituição")]
        public string NomeInstituicao { get; set; }

        public int? CodRBR { get; set; }
        public DateTime DataCadastro { get; set; }

        [MaxLength(20, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        public string CRM { get; set; }

        [MaxLength(20, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        public string CNPJ { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe o tipo de instituição")]
        public TipoInstituicao Tipo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe a categoria da instituição")]
        public CategoriaInstituicao Categoria { get; set; }

        [Required(ErrorMessage = "{0}: Campo obrigatório")]
        public bool CodFiliado { get; set; } //True se loja compra por um código único em outro endereço

        public EnderecoViewModel Endereco { get; set; }

        public bool Ativo { get; set; }

        public List<FuncionarioViewModel> Funcionario { get; set; }

        public UsuarioViewModel Usuario { get; set; }
    }

    public class ConsultaInstituicaoViewModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}