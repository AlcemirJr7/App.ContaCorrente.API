using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Historico
    {
        public int Id { get; protected set; }

        public string Descricao { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public Historico(string descricao)
        {
            ValidarEntidade(descricao);
        }

        public Historico(int id,string descricao)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;            
            ValidarEntidade(descricao);
        }

        public void Atualizar(string descricao)
        {
            ValidarEntidade(descricao);
        }

        private void ValidarEntidade(string descricao)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(descricao), "Descrição do histórico deve ser informado.");
            Descricao = descricao;
            DataCriacao = DateTime.UtcNow;
        }
    }
}
