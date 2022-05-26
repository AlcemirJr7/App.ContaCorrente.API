using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Pagamentos.Commands
{
    public abstract class PagamentoCommand : IRequest<Pagamento>
    {
        public int Id { get; set; }

        public string CodigoBarra { get; set; }

        public string NumeroDocumento { get; set; }

        public DateTime DataGeracao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public DateTime? DataAgendamento { get; set; }

        public int CorrentistaId { get; set; }

    }
}
