using Projeto.Entidade;
using Projeto.Servico.Models;
using System;
using System.Collections.Generic;

namespace Projeto.Servico.Models
{
    public class ModelConvertToEntity
    {
        #region Instituicao
        public Entidade.Instituicao ConverterInstituicao(InstituicaoViewModel model)
        {
            var i = new Entidade.Instituicao();
            i.Id = model.Id;
            i.NomeInstituicao = model.NomeInstituicao;
            i.CodRBR = model.CodRBR;
            i.DataCadastro = DateTime.Now;
            i.CRM = model.CRM;
            i.CNPJ = model.CNPJ;
            i.Tipo = model.Tipo;
            i.Categoria = model.Categoria;
            i.CodFiliado = model.CodFiliado;
            i.Ativo = model.Ativo;

            i.Endereco = ConverterEndereco(model.Endereco);

            i.Funcionario = new List<Entidade.Funcionario>();
            foreach (var funcionario in model.Funcionario)
            {
                i.Funcionario.Add(ConverterFuncionario(funcionario));
            }

            if (model.Usuario != null)
                i.Usuario = ConverterUsuario(model.Usuario);
            return i;
        }
        #endregion

        #region Endereco
        public Entidade.Endereco ConverterEndereco(EnderecoViewModel model)
        {
            var e = new Entidade.Endereco();
            e.Localizacao = new Entidade.GeoLocalizacao();

            e.Id = model.Id;
            e.Logradouro = model.Logradouro;
            e.Numero = model.Numero;
            e.Complemento = model.Complemento;
            e.Bairro = model.Bairro;
            e.Cidade = model.Cidade;
            e.UF = model.UF;
            e.CEP = model.CEP;
            if (model.Localizacao != null)
            {
                e.Localizacao.Latitude = model.Localizacao.Latitude;
                e.Localizacao.Longitude = model.Localizacao.Longitude;
            }
            return e;
        }
        #endregion

        #region Funcionario
        public Entidade.Funcionario ConverterFuncionario(FuncionarioViewModel model)
        {
            var f = new Entidade.Funcionario();
            f.Instituicao = new Entidade.Instituicao();

            f.Id = model.Id;
            f.Nome = model.Nome;
            f.Sobrenome = model.Sobrenome;
            f.Cargo = model.Cargo;
            f.DDD = model.DDD;
            f.Telefone = model.Telefone;
            return f;
        }
        #endregion

        #region Usuario
        public Entidade.Usuario ConverterUsuario(UsuarioViewModel model)
        {
            var u = new Entidade.Usuario();

            u.Id = model.Id;
            u.Nome = model.Nome;
            u.Regional = model.Regional;
            u.Tipo = model.Tipo;
            u.CodRBR = model.CodRBR;
            u.Login = model.Login;
            return u;
        }
        #endregion

        #region Visita
        public Entidade.Visita ConverterVisita(VisitaViewModel model)
        {
            var v = new Entidade.Visita();
            v.Usuario = new Entidade.Usuario();
            v.Instituicao = new Entidade.Instituicao();

            v.Id = model.Id;
            v.Data = model.DataVisita;
            v.Usuario.Id = model.Usuario.Id;
            v.Instituicao.Id = model.Instituicao.Id;
            v.Localizacao = ConverterGeolocalizacao(model.GeoLocalizacao);
            v.Descricao = ConverterDescricaoVisita(model.Descricao);
            v.Concorrencia = new List<Entidade.Concorrencia>();
            foreach (var concorrencia in model.Concorrencia)
            {
                v.Concorrencia.Add(ConverterConcorrencia(concorrencia));
            }
            return v;
        }

        public Entidade.Visita ConverterVisitaCadastro(CadastroVisitaViewModel model)
        {
            var v = new Entidade.Visita();
            v.Usuario = new Entidade.Usuario();
            v.Instituicao = new Entidade.Instituicao();

            v.Id = model.IdVisita;
            v.Data = model.DataVisita;
            v.Usuario.Id = model.IdUsuario;
            v.Instituicao.Id = model.IdInstituicao;
            v.Localizacao = ConverterGeolocalizacao(model.GeoLocalizacao);
            v.Descricao = ConverterDescricaoVisita(model.Descricao);

            if (model.Descricao.IdFuncionario != null)
            {
                v.Descricao.Funcionario = new List<Entidade.Funcionario>();
                foreach (var idFuncionario in model.Descricao.IdFuncionario)
                {
                    v.Descricao.Funcionario.Add(new Entidade.Funcionario() { Id = idFuncionario });
                }
            }
            if (model.IdConcorrencia != null)
            {
                v.Concorrencia = new List<Entidade.Concorrencia>();
                foreach (var idConcorrencia in model.IdConcorrencia)
                {
                    v.Concorrencia.Add(new Entidade.Concorrencia() { Id = idConcorrencia });
                }
            }

            return v;
        }
        #endregion

        #region DescricaoVisita
        public Entidade.DescricaoVisita ConverterDescricaoVisita(DescricaoVisitaModel model)
        {
            var d = new DescricaoVisita();
            d.Comentario = model.Comentario;
            d.ObjetivoString = model.ObjetivoString;

            if (model.Funcionario != null)
            {
                d.Funcionario = new List<Entidade.Funcionario>();
                foreach (var funcionario in model.Funcionario)
                {
                    d.Funcionario.Add(ConverterFuncionario(funcionario));
                }
            }

            return d;
        }
        #endregion

        #region Geolocalizacao
        public Entidade.GeoLocalizacao ConverterGeolocalizacao(GeoLocalizacaoModel model)
        {
            var g = new Entidade.GeoLocalizacao();

            g.Latitude = model.Latitude;
            g.Longitude = model.Longitude;
            return g;
        }
        #endregion

        #region Concorrencia
        public Entidade.Concorrencia ConverterConcorrencia(ConcorrenciaViewModel model)
        {
            var c = new Entidade.Concorrencia();

            c.Id = model.Id;
            c.Titulo = model.Titulo;
            c.Empresa = model.Empresa;
            c.TipoString = model.TipoString;
            c.Descricao = model.Descricao;
            c.DataCadastro = model.DataCadastro;
            c.Usuario = ConverterUsuario(model.Usuario);
            return c;
        }
        #endregion
    }
}