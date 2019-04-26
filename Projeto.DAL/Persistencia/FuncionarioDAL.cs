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
    public class FuncionarioDAL
    {
        /// <summary>
        /// Cadastra uma lista de Funcionarios da instituicao e, em seguida, chama o método de
        /// cadastro de relacionamento entre Funcionario e Instituicao
        /// </summary>
        /// <param name="lista"></param>
        public void Cadastrar(List<Funcionario> lista, long idInstituicao)
        {
            if (Id.IsEmpty(idInstituicao)) new ArgumentException("idInstituicão inválido", idInstituicao.ToString());

            using (var c = new Conexao())
            {
                try
                {
                    c.tr = c.con.BeginTransaction();

                    var query = "insert into Funcionario (idFuncionario, nome, sobrenome, cargo, ddd, telefone)" +
                        "values (@idFuncionario, @nome, @sobrenome, @cargo, @ddd, @telefone)";

                    foreach (var funcionario in lista)
                    {
                        funcionario.Id = Id.NewId();//TODO - Apagar dps dos testes

                        c.cmd = new SqlCommand(query, c.con, c.tr);
                        c.cmd.Parameters.AddWithValue("@idFuncionario", funcionario.Id);
                        c.cmd.Parameters.AddWithValue("@nome", funcionario.Nome.ToString());
                        c.cmd.Parameters.AddWithValue("@sobrenome", funcionario.Sobrenome.ToString());
                        c.cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo.ToString());
                        c.cmd.Parameters.AddWithValue("@ddd", funcionario.DDD.ToString());
                        c.cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone.ToString());
                        c.cmd.ExecuteNonQuery();
                    }
                    CadastrarRelacionamento(lista, idInstituicao, c);
                    c.tr.Commit();
                }
                catch
                {
                    c.tr.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Cadastra relacionamento entre Funcionário e Intituição
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="idInstituicao"></param>
        /// <param name="conection"></param>
        public void CadastrarRelacionamento(List<Funcionario> lista, long idInstituicao, Conexao connection = null)
        {
            var c = connection;
            if (c is null)
            {
                c = new Conexao();
                c.tr = c.con.BeginTransaction("relacionamento");
            }

            try
            {
                var query = "insert into Instituicao_Funcionario (idInstituicao, idFuncionario) values (@idInstituicao, @idFuncionario)";

                foreach (var funcionario in lista)
                {
                    c.cmd = new SqlCommand(query, c.con, c.tr);
                    c.cmd.Parameters.AddWithValue("@idInstituicao", idInstituicao);
                    c.cmd.Parameters.AddWithValue("@idFuncionario", funcionario.Id);
                    c.cmd.ExecuteNonQuery();
                }

                if (connection is null)
                {
                    c.tr.Commit();
                    c.Dispose();
                }
            }
            catch
            {
                if (connection is null)
                {
                    c.tr.Rollback();
                    c.Dispose();
                }
                throw;
            }
        }
    }
}
