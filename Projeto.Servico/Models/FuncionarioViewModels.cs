using Projeto.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Servico.Models
{
    //Serve tanto para Cadastro como Edicao
    public class FuncionarioViewModel
    {
        public long Id { get; set; }

        [MaxLength(50, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0} do funcionário")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0} do funcionário")]
        public string Sobrenome { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecione o Cargo do funcionário")]
        public Cargo Cargo { get; set; }

        [MaxLength(2, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0} do funcionário")]
        public string DDD { get; set; }

        [MaxLength(10, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0} do funcionário")]
        public string Telefone { get; set; }
    }

}