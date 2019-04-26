using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidade
{
    public class Concorrencia
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public Empresa Empresa { get; set; }
        public List<TipoConcorrencia> Tipo { get; set; }
        public string TipoString { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public Usuario Usuario { get; set; }
    }

    public enum TipoConcorrencia
    {
        //TODO - criar uma tabela para essas informações
        Produto = 1,
        Markup = 2,
        Marketing = 3,
        Guelta = 4,
        Prazo = 5,
        Outro = 6
    }

    public enum Empresa
    {
        Essilor = 1,
        Hoya = 2,
        Zeiss = 3,
        Lentrix = 4,
        Outro = 5
    }
}
