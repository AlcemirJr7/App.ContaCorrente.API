using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands
{
    public abstract class LancamentoFuturoCommand : IRequest<LancamentoFuturo>
    {
        public int Id { get; set; }

        public decimal Valor { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public DateTime DataParaLancamento { get; set; }

        public EnumTipoLancamentoFuturo TipoLancamento { get; set; }

        public EnumLancamentoFuturo FlagLancamento { get; set; }

        public string? Observacao { get; set; }

        public DateTime? DataLancamento { get; set; }

        public int HistoricoId { get; set; }

        public int CorrentistaId { get; set; }
    }
}
