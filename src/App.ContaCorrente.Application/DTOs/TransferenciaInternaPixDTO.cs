using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class TransferenciaInternaPixDTO
    {
        public TransferenciaInternaPixDTO()
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

        public string? ChavePixRecebe { get; set; }

        public string? ChavePixEnvia { get; set; }

        public string? Mensagen { get; set; }

    }
}
