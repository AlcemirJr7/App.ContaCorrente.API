using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Banco
    {
        public int Id { get; protected set; }

        public string Nome{ get; private set; }

        public string NomeCompleto { get; private set; }

        public Banco(string nome, string nomeCompleto)
        {
            ValidarEntidade(nome,nomeCompleto);
        }

        public Banco(int id,string nome, string nomeCompleto)
        {                        
            DomainExcepitonValidacao.When(id <= 0, "Id Invalido.");
            Id = id;
            ValidarEntidade(nome, nomeCompleto);
        }

        public void Atualizar(string nome, string nomeCompleto)
        {
            ValidarEntidade(nome, nomeCompleto);
        }

        private void ValidarEntidade(string nome, string nomeCompleto)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(nome),"Nome do Banco deve ser informado.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(nomeCompleto), "Nome Completo do Banco deve ser informado.");

            Nome = nome;
            NomeCompleto = nomeCompleto;
        }

    }
}
