using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Servico.Models
{
    //Serve tanto para Cadastro como Edicao
    public class EnderecoViewModel
    {
        public long Id { get; set; }

        [MaxLength(100, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0}")]
        public string Logradouro { get; set; }

        [MaxLength(50, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        public string Complemento { get; set; }

        [MaxLength(50, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0}")]
        public string Bairro { get; set; }

        [MaxLength(20, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha a {0}")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0}")]
        public string UF { get; set; }

        [MaxLength(8, ErrorMessage = "{0}: Máximo de {1} caractéres")]
        [Required(ErrorMessage = "Preencha o {0}")]
        public string CEP { get; set; }

        public GeoLocalizacaoModel Localizacao { get; set; }
    }
}