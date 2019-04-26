using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidade
{
    public class Funcionario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Cargo Cargo { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }

        public Instituicao Instituicao { get; set; }
    }

    public enum Cargo
    {
        Balconista = 1,
        Gerente = 2,
        Lojista = 3,
        Secretaria = 4,
        Outro = 5
    }
}
