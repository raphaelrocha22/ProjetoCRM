using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.Configuracoes
{
    public class Conexao:IDisposable
    {
        public SqlConnection con { get; set; }
        public SqlCommand cmd { get; set; }
        public SqlDataReader dr { get; set; }
        public SqlTransaction tr { get; set; }

        public Conexao()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
            con.Open();
        }

        public void Dispose()
        {
            con.Close();
        }
    }
}
