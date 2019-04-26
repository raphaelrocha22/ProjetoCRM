using Projeto.DAL.Configuracoes;
using Projeto.Entidade;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entidade.Enum;

namespace Projeto.DAL.Persistencia
{
    public class InstituicaoDAL
    {
        /// <summary>
        /// Cadastra Instituição e Endereço
        /// </summary>
        /// <param name="instituicao"></param>
        public void Cadastrar(Instituicao instituicao)
        {
            using (var c = new Conexao())
            {
                try
                {
                    c.tr = c.con.BeginTransaction();

                    var query = "insert into Endereco (idEndereco,logradouro,numero,complemento,bairro,cidade,uf,cep,latitude,longitude) " +
                        "values (@idEndereco,@logradouro,@numero,@complemento,@bairro,@cidade,@uf,@cep,@latitude,@longitude)";
                    c.cmd = new SqlCommand(query, c.con, c.tr);
                    c.cmd.Parameters.AddWithValue("@idEndereco", instituicao.Endereco.Id);
                    c.cmd.Parameters.AddWithValue("@logradouro", instituicao.Endereco.Logradouro);
                    c.cmd.Parameters.AddWithValue("@numero", (object)instituicao.Endereco.Numero?? DBNull.Value);
                    c.cmd.Parameters.AddWithValue("@complemento", (object)instituicao.Endereco.Complemento ?? DBNull.Value);
                    c.cmd.Parameters.AddWithValue("@bairro", instituicao.Endereco.Bairro);
                    c.cmd.Parameters.AddWithValue("@cidade", instituicao.Endereco.Cidade);
                    c.cmd.Parameters.AddWithValue("@uf", instituicao.Endereco.UF);
                    c.cmd.Parameters.AddWithValue("@cep", instituicao.Endereco.CEP);
                    c.cmd.Parameters.AddWithValue("@latitude", (object)instituicao.Endereco.Localizacao.Latitude ?? DBNull.Value);
                    c.cmd.Parameters.AddWithValue("@longitude", (object)instituicao.Endereco.Localizacao.Longitude ?? DBNull.Value);
                    c.cmd.ExecuteNonQuery();

                    query = "insert into Instituicao (idInstituicao ,tipo,cnpjCrm,codRbr,categoria,codFiliado,idEndereco,dataCadastro,idUsuarioCadastro) " +
                        "values (@idInstituicao,@tipo,@cnpjCrm,@codRbr,@categoria,@codFiliado,@idEndereco,@dataCadastro,@idUsuarioCadastro)";
                    c.cmd = new SqlCommand(query, c.con, c.tr);
                    c.cmd.Parameters.AddWithValue("@idInstituicao", instituicao.Id);
                    c.cmd.Parameters.AddWithValue("@tipo", instituicao.Tipo.ToString());
                    c.cmd.Parameters.AddWithValue("@cnpjCrm", instituicao.Tipo.Equals(TipoInstituicao.Medico) ? instituicao.CRM : instituicao.CNPJ);
                    c.cmd.Parameters.AddWithValue("@codRbr", (object)instituicao.CodRBR ?? DBNull.Value);
                    c.cmd.Parameters.AddWithValue("@categoria", instituicao.Categoria.ToString());
                    c.cmd.Parameters.AddWithValue("@codFiliado", instituicao.CodFiliado);
                    c.cmd.Parameters.AddWithValue("@idEndereco", instituicao.Endereco.Id);
                    c.cmd.Parameters.AddWithValue("@dataCadastro", instituicao.DataCadastro);
                    c.cmd.Parameters.AddWithValue("@idUsuarioCadastro", instituicao.Usuario.Id);
                    c.cmd.ExecuteNonQuery();
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
        /// Edita informações da Instituição e do Endereço
        /// </summary>
        /// <param name="instituicao"></param>
        public void Editar(Instituicao instituicao)
        {
            using (var c = new Conexao())
            {
                try
                {
                    c.tr = c.con.BeginTransaction();

                    var query = "update Endereco set logradouro = @logradouro, numero = @numero, complemento = @complemento, " +
                        "bairro = @bairro, cidade = @cidade, uf = @uf, cep = @cep, latitude = @latitude, longitude = @longitude " +
                        "where idEndereco = @idEndereco";
                    c.cmd = new SqlCommand(query, c.con, c.tr);
                    c.cmd.Parameters.AddWithValue("@idEndereco", instituicao.Endereco.Id);
                    c.cmd.Parameters.AddWithValue("@logradouro", instituicao.Endereco.Logradouro);
                    c.cmd.Parameters.AddWithValue("@numero", instituicao.Endereco.Numero);
                    c.cmd.Parameters.AddWithValue("@complemento", instituicao.Endereco.Complemento);
                    c.cmd.Parameters.AddWithValue("@bairro", instituicao.Endereco.Bairro);
                    c.cmd.Parameters.AddWithValue("@cidade", instituicao.Endereco.Cidade);
                    c.cmd.Parameters.AddWithValue("@uf", instituicao.Endereco.UF);
                    c.cmd.Parameters.AddWithValue("@cep", instituicao.Endereco.CEP);
                    c.cmd.Parameters.AddWithValue("@latitude", instituicao.Endereco.Localizacao.Latitude);
                    c.cmd.Parameters.AddWithValue("@longitude", instituicao.Endereco.Localizacao.Longitude);
                    c.cmd.ExecuteNonQuery();

                    query = "update Instituicao set tipo = @tipo, cnpjCrm = @cnpjCrm, codRbr = @codRbr, categoria = @categoria, codFiliado = @codFiliado " +
                        "where idInstituicao = @idInstituicao";
                    c.cmd = new SqlCommand(query, c.con, c.tr);
                    c.cmd.Parameters.AddWithValue("@idInstituicao", instituicao.Id);
                    c.cmd.Parameters.AddWithValue("@tipo", instituicao.Tipo.ToString());
                    c.cmd.Parameters.AddWithValue("@cnpjCrm", instituicao.Tipo.Equals(TipoInstituicao.Medico) ? instituicao.CRM : instituicao.CNPJ);
                    c.cmd.Parameters.AddWithValue("@codRbr", instituicao.CodRBR);
                    c.cmd.Parameters.AddWithValue("@categoria", instituicao.Categoria.ToString());
                    c.cmd.Parameters.AddWithValue("@codFiliado", instituicao.CodFiliado);
                    c.cmd.ExecuteNonQuery();
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
        /// Define a coluna Ativo da Instituição e do Endereço como False
        /// </summary>
        /// <param name="idInstituicao"></param>
        public void Deletar(long idInstituicao)
        {
            using (var c = new Conexao())
            {
                try
                {
                    c.tr = c.con.BeginTransaction();

                    var query = "update Instituicao set ativo = 0 where idInstituicao = @idInstituicao " +
                        "select idEndereco from Instituicao where idInstituicao = @idInstituicao";
                    c.cmd = new SqlCommand(query, c.con, c.tr);
                    c.cmd.Parameters.AddWithValue("@idInstituicao", idInstituicao);
                    var idEndereco = Convert.ToInt64(c.cmd.ExecuteScalar());

                    if (!Id.IsEmpty(idEndereco))
                    {
                        query = "update Endereco set ativo = 0 where idEndereco = @idEndereco";
                        c.cmd = new SqlCommand(query, c.con, c.tr);
                        c.cmd.Parameters.AddWithValue("@idEndereco", idEndereco);
                        c.cmd.ExecuteNonQuery();
                        c.tr.Commit();
                    }
                    else
                    {
                        throw new ArgumentException("idEndereco não encontrado", "idEndereco");
                    }
                }
                catch
                {
                    c.tr.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Retorna todas as Instituições e Endereços, sem filtro
        /// </summary>
        /// <returns>Lista de Instituição com Endereco (todos os campos)</returns>
        public List<Instituicao> Consultar()
        {
            using (var c = new Conexao())
            {
                var query = "select i.idInstituicao, i.razaoSocial, i.nomeFantasia, i.tipo, i.cnpjCrm, i.codRBR, i.categoria, i.codFiliado, i.dataCadastro, i.ativo, " +
                    "e.idEndereco, e.logradouro, e.numero, e.complemento, e.bairro, e.cidade, e.uf, e.cep, ISNULL(e.latitude,0) latitude, ISNULL(e.longitude,0) longitude " +
                    "from Instituicao i left join Endereco e on i.idEndereco = e.idEndereco";
                c.cmd = new SqlCommand(query, c.con);
                return Consultar(c.cmd.ExecuteReader());
            }
        }

        /// <summary>
        /// Recebe um SqlDataReader configurado com o SqlCommand para consulta ao banco
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>Lista de Instituição com Endereco (todos os campos)</returns>
        private List<Instituicao> Consultar(SqlDataReader dr)
        {
            var lista = new List<Instituicao>();
            while (dr.Read())
            {
                var i = new Instituicao();
                i.Endereco = new Endereco();
                i.Endereco.Localizacao = new GeoLocalizacao();

                i.Id = Convert.ToInt64(dr["idInstituicao"]);
                i.RazaoSocial = dr["razaoSocial"].ToString();
                i.NomeFantasia = dr["nomeFantasia"].ToString();
                i.Tipo = (TipoInstituicao)Enum.Parse(typeof(TipoInstituicao), dr["tipo"].ToString());
                i.CodRBR = int.TryParse(dr["codRBR"].ToString(), out int valor) ? (int?)valor : null;
                i.Categoria = (CategoriaInstituicao)Enum.Parse(typeof(CategoriaInstituicao), dr["categoria"].ToString());
                i.CodFiliado = (bool)dr["codFiliado"];
                i.DataCadastro = (DateTime)dr["dataCadastro"];
                if (i.Tipo.Equals(TipoInstituicao.Medico))
                    i.CRM = dr["cnpjCrm"].ToString();
                else
                    i.CNPJ = dr["cnpjCrm"].ToString();
                i.Ativo = (bool)dr["ativo"];

                i.Endereco.Id = Convert.ToInt64(dr["idEndereco"]);
                i.Endereco.Logradouro = dr["logradouro"].ToString();
                i.Endereco.Numero = dr["numero"].ToString();
                i.Endereco.Complemento = dr["complemento"].ToString();
                i.Endereco.Bairro = dr["bairro"].ToString();
                i.Endereco.Cidade = dr["cidade"].ToString();
                i.Endereco.UF = dr["uf"].ToString();
                i.Endereco.CEP = dr["cep"].ToString();
                i.Endereco.Localizacao.Latitude = (decimal)dr["latitude"];
                i.Endereco.Localizacao.Longitude = (decimal)dr["longitude"];

                lista.Add(i);
            }
            return lista;
        }
    }
}
