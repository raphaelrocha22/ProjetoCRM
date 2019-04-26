using Projeto.DAL.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.Persistencia
{
    public class InstituicaoUsuarioDAL
    {
        /// <summary>
        /// Cadastra o relacionamento entre Usuario e Instituicao no banco e grava o Nome Customizável da Instituição (definido pelo usuário)
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idInstituicao"></param>
        /// <param name="nomeInstituicao"></param>
        public void Cadastrar(int idUsuario, long idInstituicao, string nomeInstituicao)
        {
            using (var c = new Conexao())
            {
                var query = "insert into Instituicao_Usuario (idInstituicao,idUsuario,nomeInstituicao,dataCadastro) " +
                    "values (@idInstituicao,@idUsuario,@nomeInstituicao,@dataCadastro)";
                c.cmd = new SqlCommand(query, c.con);
                c.cmd.Parameters.AddWithValue("@idInstituicao", idInstituicao);
                c.cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                c.cmd.Parameters.AddWithValue("@nomeInstituicao", nomeInstituicao);
                c.cmd.Parameters.AddWithValue("@dataCadastro", DateTime.Now);
                c.cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deleta relacionamento entre Usuário e Instituição
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idInstituicao"></param>
        public void Deletar(int idUsuario, long idInstituicao)
        {
            using (var c = new Conexao())
            {
                var query = "delete from Instituicao_Usuario where idInstituicao = @idInstituicao and idUsuario = @idUsuario";
                c.cmd = new SqlCommand(query, c.con);
                c.cmd.Parameters.AddWithValue("@idInstituicao", idInstituicao);
                c.cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                c.cmd.ExecuteNonQuery();
            }
        }
    }
}
