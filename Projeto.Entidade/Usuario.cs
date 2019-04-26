using Projeto.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidade
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Regional Regional { get; set; }
        public TipoUsuario Tipo { get; set; }
        public int CodRBR { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public List<Instituicao> Instituicao { get; set; }
        public List<Visita> Visita { get; set; }

        public Usuario()
        {
            Id = 100;
            Nome = "Raphael da Rocha Fonseca";
            Regional = Regional.SECO;
            Tipo = TipoUsuario.Administrativo;
            CodRBR = 100;
            Login = "raphael.rocha@rodenstock.com.br";

            var senha = "raphael22";
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(senha));

            senha = BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
