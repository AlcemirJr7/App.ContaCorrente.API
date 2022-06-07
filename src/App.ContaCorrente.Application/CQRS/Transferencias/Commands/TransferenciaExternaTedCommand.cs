using App.ContaCorrente.Domain.Entidades.Transferencias;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Transferencias.Commands
{
    public abstract class TransferenciaExternaTedCommand : IRequest<Transferencia>
    {
        public int Id { get; set; }

        public DateTime? DataTransferencia { get; set; }

        public DateTime DataCadatro { get; set; }

        public decimal Valor { get; set; }

        public EnumTransferenciaTipo TipoTransferencia { get; set; }

        public EnumTransferenciaModo ModoTransferencia { get; set; }

        public DateTime? DataAgendamento { get; set; }

        public int? CorrentistaEnviaId { get; set; }

        public int? CodigoBancoExterno { get; set; }

        public string? CodigoAgenciaEterno { get; set; }

        public string? NumeroContaExtero { get; set; }

        public string? NomePessoaExtero { get; set; }

        public string? NumeroDocumentoExterno { get; set; }

        public string? Mensagem { get; set; }

    }
}
