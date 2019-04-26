using Projeto.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Servico.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Regional Regional { get; set; }
        public TipoUsuario Tipo { get; set; }
        public int CodRBR { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}