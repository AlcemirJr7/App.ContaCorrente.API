using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Pagamento
    {
        public int Id { get; protected set; }

        public string CodigoBarra { get; private set; }

        public string NumeroDocumento { get; private set; }

        public DateTime DataGeracao { get; private set; }

        public decimal Valor { get; private set; }

        public DateTime DataVencimento { get; private set; }

        public DateTime? DataPagamento { get; private set; }

        public DateTime? DataAgendamento { get; private set; }

        public int CorrentistaId { get; set; }

        public Correntista Correntista { get; set; }

        public Pagamento(string codigoBarra, string numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime? dataPagamento, DateTime? dataAgendamento)
        {
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento,dataAgendamento);
        }

        public Pagamento(int id,string codigoBarra, string numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime? dataPagamento, DateTime? dataAgendamento)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento,dataAgendamento);
        }

        public Pagamento(string codigoBarra, string numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime? dataPagamento, DateTime? dataAgendamento, int correntistaId)
        {
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento,dataAgendamento);
            CorrentistaId = correntistaId;
        }

        public void Atualizar(string codigoBarra, string numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime? dataPagamento, DateTime? dataAgendamento, int correntistaId)
        {
            ValidarEntidade(codigoBarra, numeroDocumento, dataGeracao, valor, dataVencimento, dataPagamento, dataAgendamento);
            CorrentistaId = correntistaId;
        }

        private void ValidarEntidade(string codigoBarra, string numeroDocumento, DateTime dataGeracao, decimal valor, DateTime dataVencimento, DateTime? dataPagamento, DateTime? dataAgendamento)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(codigoBarra)),"Codigo de Barra invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(numeroDocumento)), "Numero do documento invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataGeracao)), "Data geração invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataVencimento)), "Data vencimento invalido.");           
            DomainExcepitonValidacao.When(valor < 0, "Valor invalido.");

            CodigoBarra = StringFormata.ApenasNumeros(codigoBarra);  
            NumeroDocumento = StringFormata.ApenasNumeros(numeroDocumento);
            DataGeracao = dataGeracao;
            Valor = valor;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            DataAgendamento = dataAgendamento;

        }
    }
}
