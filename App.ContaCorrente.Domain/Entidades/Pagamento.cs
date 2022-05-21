using App.ContaCorrente.Domain.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Pagamento
    {
        public int Id { get; protected set; }

        public string CodigoBarra { get; private set; }

        public int NumeroDocumento { get; private set; }

        public DateTime DataGeracao { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime DataVencimento { get; private set; }

        public DateTime DataPagamento { get; private set; }

        public int CorrentistaId { get; set; }

        public Correntista Correntista { get; set; }

        public Pagamento(string codigoBarra, int numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime dataPagamento)
        {
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento);
        }

        public Pagamento(int id,string codigoBarra, int numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime dataPagamento)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento);
        }

        public Pagamento(string codigoBarra, int numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime dataPagamento, int correntistaId)
        {
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento);
            CorrentistaId = correntistaId;
        }

        public void Atualizar(string codigoBarra, int numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime dataPagamento, int correntistaId)
        {
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento);
            CorrentistaId = correntistaId;
        }

        private void ValidarEntidade(string codigoBarra, int numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime dataPagamento)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(codigoBarra),"Codigo de Barra invalido.");
            DomainExcepitonValidacao.When(numeroDocumento < 0, "Numero do documento invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataGeracao)), "Data geração invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataVencimento)), "Data vencimento invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataPagamento)), "Data pagamento invalido.");
            DomainExcepitonValidacao.When(valor < 0, "Valor invalido.");

            CodigoBarra = codigoBarra;  
            NumeroDocumento = numeroDocumento;
            DataGeracao = dataGeracao;
            Valor = valor;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;

        }
    }
}
