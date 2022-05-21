using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Lancamento
    {
        public int Id { get; protected set; }

        public DateTime DataLancamento { get; private set; }

        public decimal Valor { get; private set; }

        public string? Observacao { get; private set; }   

        public int CorrentistaId { get; set; }

        public Correntista Correntista { get; set; }

        public int HistoricoId { get; set; }

        public Historico Historico { get; set; }

        public Lancamento(DateTime dataLancamento, decimal valor,string? observacao)
        {
            ValidarEntidade(dataLancamento, valor, observacao);
        }

        public Lancamento(int id,DateTime dataLancamento, decimal valor, string? observacao)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(dataLancamento, valor, observacao);
        }

        public Lancamento(DateTime dataLancamento, decimal valor, string? observacao,int correntistaId, int historicoId)
        {
            ValidarEntidade(dataLancamento, valor, observacao);
            CorrentistaId = correntistaId;
            HistoricoId = historicoId;
        }

        public void Atualizar(DateTime dataLancamento, decimal valor, string? observacao, int correntistaId, int historicoId)
        {
            ValidarEntidade(dataLancamento, valor, observacao);
            CorrentistaId = correntistaId;
            HistoricoId = historicoId;
        }
        private void ValidarEntidade(DateTime dataLancamento, decimal valor, string? observacao)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataLancamento)), "Data de lançamento invalido.");
            DomainExcepitonValidacao.When(valor < 0, "Valor de lançamento invalido.");

            DataLancamento = dataLancamento;
            Valor = valor;
            Observacao = observacao;
        }

    }
}
