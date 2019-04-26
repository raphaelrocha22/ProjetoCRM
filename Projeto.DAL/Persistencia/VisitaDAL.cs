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
    public class VisitaDAL
    {
        /// <summary>
        /// Cadastra Visita no banco.
        /// Se Concorrencia não nulo, cadastra ação da concorrencia.
        /// Se Funcionário não nulo, cadastra funcionários.
        /// </summary>
        /// <param name="visita"></param>
        public void Cadastrar(Visita visita)
        {
            using (var c = new Conexao())
            {
                try
                {
                    c.tr = c.con.BeginTransaction();

                    var query = "insert into visita (idVisita, data, latitude, longitude, objetivo, comentario, idUsuario, idInstituicao) " +
                        "values (@idVisita, @data, @latitude, @longitude, @objetivo, @comentario, @idUsuario, @idInstituicao)";
                    c.cmd = new SqlCommand(query, c.con, c.tr);
                    c.cmd.Parameters.AddWithValue("@idVisita", visita.Id);
                    c.cmd.Parameters.AddWithValue("@data", visita.Data);
                    c.cmd.Parameters.AddWithValue("@latitude", visita.Localizacao.Latitude);
                    c.cmd.Parameters.AddWithValue("@longitude", visita.Localizacao.Longitude);
                    c.cmd.Parameters.AddWithValue("@objetivo", visita.Descricao.ObjetivoString);
                    c.cmd.Parameters.AddWithValue("@comentario", visita.Descricao.Comentario);
                    c.cmd.Parameters.AddWithValue("@idUsuario", visita.Usuario.Id);
                    c.cmd.Parameters.AddWithValue("@idInstituicao", visita.Instituicao.Id);
                    c.cmd.ExecuteNonQuery();

                    if (visita.Concorrencia != null)
                    {
                        query = "insert into Visita_Concorrencia (idVisita,idConcorrencia) values (@idVisita,@idConcorrencia)";
                        foreach (var concorrencia in visita.Concorrencia)
                        {
                            c.cmd = new SqlCommand(query, c.con, c.tr);
                            c.cmd.Parameters.AddWithValue("@idVisita", visita.Id);
                            c.cmd.Parameters.AddWithValue("@idConcorrencia", concorrencia.Id);
                            c.cmd.ExecuteNonQuery();
                        }
                    }

                    if (visita.Descricao.Funcionario != null)
                    {
                        query = "insert into Visita_Funcionario (idVisita,idFuncionario) values (@idVisita,@idFuncionario)";
                        foreach (var funcionario in visita.Descricao.Funcionario)
                        {
                            c.cmd = new SqlCommand(query, c.con, c.tr);
                            c.cmd.Parameters.AddWithValue("@idVisita", visita.Id);
                            c.cmd.Parameters.AddWithValue("@idFuncionario", funcionario.Id);
                            c.cmd.ExecuteNonQuery();
                        }
                    }

                    c.tr.Commit();
                }
                catch
                {
                    c.tr.Rollback();
                    throw;
                }
            }
        }
    }
}
