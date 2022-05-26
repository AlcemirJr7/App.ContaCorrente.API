using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class ParcelasEmprestimo
    {
        public int Id { get; protected set; }

        public decimal Valor { get; private set; }

        public int SeqParcelas { get; private set; }

        public DateTime DataVencimento { get; private set; }

        public DateTime? DataPagamento { get; private set; }

        public int EmprestimoId { get; set; }

        public Emprestimo Emprestimo { get; set; }

        public ParcelasEmprestimo(decimal valor, int seqParcelas , DateTime dataVencimento, DateTime? dataPagamento)
        {
            ValidarEntidade(valor, seqParcelas, dataVencimento, dataPagamento);
        }

        public ParcelasEmprestimo(decimal valor, int seqParcelas, DateTime dataVencimento, DateTime? dataPagamento, int emprestimoId)
        {
            ValidarEntidade(valor, seqParcelas, dataVencimento, dataPagamento);
            EmprestimoId = emprestimoId;
        }


        public ParcelasEmprestimo(int id,decimal valor, int seqParcelas, DateTime dataVencimento, DateTime? dataPagamento)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(valor, seqParcelas, dataVencimento, dataPagamento);
        }

        public void Atualizar(decimal valor, int seqParcelas, DateTime dataVencimento, DateTime? dataPagamento, int emprestimoId)
        {
            ValidarEntidade(valor, seqParcelas, dataVencimento, dataPagamento);
            EmprestimoId = emprestimoId;
        }

        private void ValidarEntidade(decimal valor, int seqParcelas, DateTime dataVencimento, DateTime? dataPagamento)
        {
            DomainExcepitonValidacao.When(valor <= 0, "Valor da parcela do emprestimo invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataVencimento)), "Data de vencimento do emprestimo deve ser informado.");
            DomainExcepitonValidacao.When(seqParcelas <= 0, "Sequencia da parcela do emprestimo invalido.");


            Valor = valor;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            SeqParcelas = seqParcelas;
        }
    }
}
