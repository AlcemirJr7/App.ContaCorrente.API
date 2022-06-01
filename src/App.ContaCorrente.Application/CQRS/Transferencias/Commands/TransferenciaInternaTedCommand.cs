using App.ContaCorrente.Domain.Entidades.Transferencias;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Transferencias.Commands
{
    public abstract class TransferenciaInternaTedCommand : IRequest<Transferencia>
    {
        public int Id { get; set; }

        public DateTime? DataTransferencia { get; set; }
        
        public DateTime DataCadatro { get; set; }

        public decimal Valor { get; set; }
        
        public EnumTransferenciaTipo TipoTransferencia { get; set; }
        
        public EnumTransferenciaModo ModoTransferencia { get; set; }
       
        public DateTime? DataAgendamento { get; set; }

        public string? NumeroContaRecebe { get; set; }

        public string? NumeroContaEnvia { get; set; }

        public int CorrentistaRecebeId { get; set; }

        public int CorrentistaEnviaId { get; set; }
    }
}
