using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class TransferenciaExternaEnviaPixDTO
    {
        public TransferenciaExternaEnviaPixDTO()
        {

        }

        public int Id { get; set; }

        public DateTime? DataTransferencia { get; set; }

        [JsonIgnore]
        public DateTime DataCadatro { get; set; }

        public decimal Valor { get; set; }
                
        public EnumChavePixTipo TipoChave { get; set; }

        public string? ChavePixEnvia { get; set; }

        public string? ChavePixRecebeExterno { get; set; }
                               
        [JsonIgnore]
        public int? CorrentistaEnviaId { get; set; }

        public string? Mensagem { get; set; }


    }
}
