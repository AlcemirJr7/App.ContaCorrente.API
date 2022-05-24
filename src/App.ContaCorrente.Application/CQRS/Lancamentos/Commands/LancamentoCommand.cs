
using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Lancamentos.Commands
{
    public abstract class LancamentoCommand : IRequest<Lancamento>
    {
        public int Id { get; set; }

        public DateTime DataLancamento { get; set; }

        public decimal Valor { get; set; }

        public string? Observacao { get; set; }

        public int CorrentistaId { get; set; }

        public int HistoricoId { get; set; }

    }
}
