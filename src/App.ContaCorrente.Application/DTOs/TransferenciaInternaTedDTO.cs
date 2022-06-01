using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class TransferenciaInternaTedDTO
    {
        public TransferenciaInternaTedDTO()
        {

        }

        public int Id { get; set; }

        public DateTime? DataTransferencia { get; set; }

        [JsonIgnore]
        public DateTime DataCadatro { get; set; }

        public decimal Valor { get; set; }

        [JsonIgnore]
        public EnumTransferenciaTipo TipoTransferencia { get; set; }

        [JsonIgnore]
        public EnumTransferenciaModo ModoTransferencia { get; set; }

        [JsonIgnore]
        public DateTime? DataAgendamento { get; set; }

        public string? NumeroContaRecebe { get; set; }

        public string? NumeroContaEnvia { get; set; }

        [JsonIgnore]
        public int CorrentistaRecebeId { get; set; }
        [JsonIgnore]
        public int CorrentistaEnviaId { get; set; }

        public string? Mensagem { get; set; }
    }
}
