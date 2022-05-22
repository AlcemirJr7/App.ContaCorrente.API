using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Pessoa
    {
        public int Id { get; protected set; } 

        public string Nome { get; private set; }

        public string? NomeEmpresa { get; private set; }

        public string NumeroDocumento { get; private set; }

        public EnumPessoa TipoPessoa { get; private set; }

        public string NumeroTelefone1 { get; private set; }

        public string? NumeroTelefone2 { get; private set; }

        public string Email1 { get; private set; }

        public string? Email2 { get; private set; }

        public DateTime DataNascimento { get; private set; }  

        public DateTime DataCadastro { get; set; }

        public int EnderecoId { get; private set; }

        public Endereco Endereco { get; private set; }


        public Pessoa(string nome, string? nomeEmpresa, string numeroDocumento, EnumPessoa tipoPessoa, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2, 
                      DateTime dataNascimento)
        {
            ValidarEntidade(nome, nomeEmpresa, numeroDocumento, tipoPessoa, numeroTelefone1, numeroTelefone2, email1, email2, dataNascimento);
        }

        public Pessoa(int id,string nome, string? nomeEmpresa, string numeroDocumento, EnumPessoa tipoPessoa, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2,
                      DateTime dataNascimento)
        {
            DomainExcepitonValidacao.When(id < 0, "Id Invalido.");
            Id = id;
            ValidarEntidade(nome, nomeEmpresa, numeroDocumento, tipoPessoa, numeroTelefone1, numeroTelefone2, email1, email2, dataNascimento);
        }

        public Pessoa(string nome, string? nomeEmpresa, string numeroDocumento, EnumPessoa tipoPessoa, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2,
                      DateTime dataNascimento, int enderecoId)
        {
            ValidarEntidade(nome, nomeEmpresa, numeroDocumento, tipoPessoa, numeroTelefone1, numeroTelefone2, email1, email2, dataNascimento);
            EnderecoId = enderecoId;             
        }

        public void Atualizar(string nome, string? nomeEmpresa, string numeroDocumento, EnumPessoa tipoPessoa, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2,
                              DateTime dataNascimento, int enderecoId)
        {
            ValidarEntidade(nome, nomeEmpresa, numeroDocumento, tipoPessoa, numeroTelefone1, numeroTelefone2, email1, email2, dataNascimento);
            EnderecoId = enderecoId;            
        }

        private void ValidarEntidade(string nome, string? nomeEmpresa, string numeroDocumento, EnumPessoa tipoPessoa, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2,
                                     DateTime dataNascimento)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(nome), "Nome deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(numeroDocumento)), "Numero do documento deve ser informado.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumPessoa), tipoPessoa), "Tipo pessoa invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(numeroTelefone1)), "Numero telefone 1 deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(email1), "Email 1 deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataNascimento)), "Data Nascimento deve ser informado.");

            if(tipoPessoa == EnumPessoa.PessoaJuridica && nomeEmpresa == null)
            {
                DomainExcepitonValidacao.When(string.IsNullOrEmpty(nomeEmpresa), "Nome Empresa deve ser informado para tipo pessoa juridica.");
            }

            Nome = nome;
            NomeEmpresa = nomeEmpresa;
            NumeroDocumento = StringFormata.ApenasNumeros(numeroDocumento);
            TipoPessoa = tipoPessoa;
            NumeroTelefone1 = StringFormata.ApenasNumeros(numeroTelefone1);
            NumeroTelefone2 = StringFormata.ApenasNumeros(numeroTelefone2);
            Email1 = email1;
            Email2 = email2;
            DataNascimento = dataNascimento;            
        }

    }
}
