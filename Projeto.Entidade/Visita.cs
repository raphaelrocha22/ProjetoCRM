using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Projeto.Entidade
{
    public class Visita
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public Instituicao Instituicao { get; set; }
        public DateTime Data { get; set; }
        public GeoLocalizacao Localizacao { get; set; }
        public DescricaoVisita Descricao { get; set; }
        public List<Concorrencia> Concorrencia { get; set; }
    }

    public class DescricaoVisita
    {
        public List<Objetivo> Objetivo { get; set; }
        public string ObjetivoString { get; set; }
        public string Comentario { get; set; }
        public List<Funcionario> Funcionario { get; set; }
    }

    public class GeoLocalizacao
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
        
    public enum Objetivo
    {
        //TODO - Criar uma tabela para essas informações
        DivulgacaoProduto = 1,
        Garantia = 2,
        Assistencia = 3,
        TabelaPreco = 4,
        Outro = 5
    }
}
