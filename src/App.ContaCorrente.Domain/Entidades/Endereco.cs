﻿using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Endereco 
    {
        public int Id { get; protected set; }

        public int Cep { get; private set; }

        public string NomeRua { get; private set; }

        public int NumeroRua { get; private set; }

        public string? Complemento { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string Sigla { get; private set; }     
                

        public Endereco(int cep, string nomeRua, int numeroRua, string complemento, string bairro, string cidade, string estado, string sigla)
        {            
            ValidarEntidade(cep, nomeRua,numeroRua, complemento, bairro, cidade, estado, sigla);
        }

        public Endereco(int id,int cep, string nomeRua, int numeroRua, string complemento, string bairro, string cidade, string estado, string sigla)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");  
                                    
            Id = id;
            ValidarEntidade(cep, nomeRua, numeroRua, complemento, bairro, cidade, estado, sigla);
                        
            
        }

        public void Atualizar(int cep, string nomeRua, int numeroRua, string complemento, string bairro, string cidade, string estado, string sigla)
        {
            ValidarEntidade(cep, nomeRua, numeroRua, complemento, bairro, cidade, estado, sigla);
        }
        
        private void ValidarEntidade(int cep, string nomeRua, int numeroRua, string complemento, string bairro, string cidade, string estado, string sigla)
        {

            DomainExcepitonValidacao.When(cep <= 0, "Cep deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(nomeRua), "Nome da Rua deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(bairro), "Bairro deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(cidade), "Cidade deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(estado), "Estado deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(sigla), "Sigla do estado deve ser informado.");

            Cep = cep;
            NomeRua = nomeRua;
            NumeroRua = numeroRua;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Sigla = sigla;                       



        }

    }
}
