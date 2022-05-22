﻿using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class LocalTrabalho
    {
        public int Id { get; protected set; }

        public string NomeEmpresa { get; private set; }

        public string NumeroDocumento { get; private set; }

        public string NumeroTelefone1 { get; private set; }
        
        public string? NumeroTelefone2 { get; private set; }

        public string Email1 { get; private set; }

        public string? Email2 { get; private set; }   

        public decimal Salario1 { get; private set; }

        public decimal? Salario2 { get; private set; }

        public DateTime DataCadastro { get; set; }

        public LocalTrabalho(string nomeEmpresa, string numeroDocumento, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2, decimal salario1, decimal? salario2)
        {
            ValidarEntidade(nomeEmpresa, numeroDocumento, numeroTelefone1, numeroTelefone2, email1, email2, salario1, salario2);
        }

        public LocalTrabalho(int id,string nomeEmpresa, string numeroDocumento, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2, decimal salario1, decimal? salario2)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(nomeEmpresa, numeroDocumento, numeroTelefone1, numeroTelefone2, email1, email2, salario1, salario2);
        }

        public void Atualizar(string nomeEmpresa, string numeroDocumento, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2, decimal salario1, decimal? salario2)
        {
            ValidarEntidade(nomeEmpresa, numeroDocumento, numeroTelefone1, numeroTelefone2, email1, email2, salario1, salario2);
        }

        private void ValidarEntidade(string nomeEmpresa, string numeroDocumento, string numeroTelefone1, string? numeroTelefone2, string email1, string? email2, decimal salario1, decimal? salario2)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(nomeEmpresa), "Nome empresa deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(numeroDocumento)), "Numero do documento deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(numeroTelefone1)), "Numero do telefone 1 deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(email1), "Email 1 deve ser informado.");
            DomainExcepitonValidacao.When(salario1 <= 0, "Salario deve ser informado.");            

            NomeEmpresa = nomeEmpresa;  
            NumeroDocumento = numeroDocumento;
            NumeroTelefone1 = numeroTelefone1;
            NumeroTelefone2 = numeroTelefone2;
            Email1 = email1;
            Email2 = email2;
            Salario1 = salario1;
            Salario2 = salario2;               


        }
       
    }
}
