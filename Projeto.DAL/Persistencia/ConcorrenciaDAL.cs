using Projeto.DAL.Configuracoes;
using Projeto.Entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.Persistencia
{
    public class ConcorrenciaDAL
    {
        /// <summary>
        /// Cadastra uma ação da concorrencia
        /// </summary>
        /// <param name="concorrencia"></param>
        public void Cadastrar(Concorrencia concorrencia)
        {
            using (var c = new Conexao())
            {
                var query = "insert into Concorrencia (idConcorrencia, empresa, tipo, titulo, descricao, idUsuario, dataCadastro) " +
                    "values (@idConcorrencia, @empresa, @tipo, @titulo, @descricao, @idUsuario, @dataCadastro)";
                c.cmd = new SqlCommand(query, c.con);
                c.cmd.Parameters.AddWithValue("@idConcorrencia", concorrencia.Id);
                c.cmd.Parameters.AddWithValue("@empresa", concorrencia.Empresa.ToString());
                c.cmd.Parameters.AddWithValue("@tipo", concorrencia.TipoString);
                c.cmd.Parameters.AddWithValue("@titulo", concorrencia.Titulo);
                c.cmd.Parameters.AddWithValue("@descricao", concorrencia.Descricao);
                c.cmd.Parameters.AddWithValue("@idUsuario", concorrencia.Usuario.Id);
                c.cmd.Parameters.AddWithValue("@dataCadastro", concorrencia.DataCadastro);
                c.cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edita uma ação da concorrencia cadastrada
        /// </summary>
        /// <param name="concorrencia"></param>
        public void Editar(Concorrencia concorrencia)
        {
            using (var c = new Conexao())
            {
                var query = "update concorrencia set empresa = @empresa, tipo = @tipo, titulo = @titulo, descricao = @descricao " +
                    "where idConcorrencia = @idConcorrencia";
                c.cmd = new SqlCommand(query, c.con);
                c.cmd.Parameters.AddWithValue("@empresa", concorrencia.Empresa.ToString());
                c.cmd.Parameters.AddWithValue("@tipo", concorrencia.TipoString);
                c.cmd.Parameters.AddWithValue("@titulo", concorrencia.Titulo);
                c.cmd.Parameters.AddWithValue("@descricao", concorrencia.Descricao);
                c.cmd.Parameters.AddWithValue("@idConcorrencia", concorrencia.Id);
                c.cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Verifica se o Usuário que deseja realizar a alteração foi o usuário que realizou o cadastro
        /// </summary>
        /// <param name="idConcorrencia"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public bool IsUsuarioHabilitado(long idConcorrencia, int idUsuario)
        {
            using (var c = new Conexao())
            {
                var query = "select idConcorrencia from Concorrencia where idConcorrencia = @idConcorrencia and idUsuario = @idUsuario";
                c.cmd = new SqlCommand(query, c.con);
                c.cmd.Parameters.AddWithValue("@idConcorrencia", idConcorrencia);
                c.cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                return Convert.ToInt64(c.cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
