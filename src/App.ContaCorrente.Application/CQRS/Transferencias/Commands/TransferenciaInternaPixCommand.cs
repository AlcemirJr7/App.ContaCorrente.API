using App.ContaCorrente.Domain.Entidades.Transferencia;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Transferencias.Commands
{
    public abstract class TransferenciaInternaPixCommand : IRequest<Transferencia>
    {
        public int Id { get; set; }

        public DateTime? DataTransferencia { get; set; }

        public DateTime DataCadatro { get; set; }

        public decimal Valor { get; set; }
        
        public EnumTransferenciaTipo TipoTransferencia { get; set; }

        public EnumTransferenciaModo ModoTransferencia { get; set; }

        public DateTime? DataAgendamento { get; set; }

        public string? ChavePixRecebe { get; set; }

        public string? ChavePixEnvia { get; set; }

        public string? Mensagen { get; set; }
    }
}
