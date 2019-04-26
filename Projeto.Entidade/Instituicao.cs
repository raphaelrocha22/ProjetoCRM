using Projeto.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidade
{
    public class Instituicao
    {
        public long Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string NomeInstituicao { get; set; }
        public int ? CodRBR { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CRM { get; set; }
        public string CNPJ { get; set; }
        public TipoInstituicao Tipo { get; set; }
        public CategoriaInstituicao Categoria { get; set; }
        public bool CodFiliado { get; set; } //True se loja compra por um código único em outro endereço
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        public Usuario Usuario { get; set; }
        public List<Visita> Visita { get; set; }
        public List<Funcionario> Funcionario { get; set; }
    }


    public enum CategoriaInstituicao
    {
        Regular = 1,
        Prospect = 2,
        Concorrente = 3
    }
}
