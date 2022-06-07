using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class TransferenciaExternaEnviaTedDTO
    {
        public TransferenciaExternaEnviaTedDTO()
        {

        }

        public int Id { get; set; }

        public DateTime? DataTransferencia { get; set; }

        [JsonIgnore]
        public DateTime DataCadatro { get; set; }

        public decimal Valor { get; set; }

        public int? CorrentistaEnviaId { get; set; }

        public int? CodigoBancoExterno { get; set; }
        
        public string? CodigoAgenciaEterno { get; set; }
        
        public string? NumeroContaExtero { get; set; }
        
        public string? NomePessoaExtero { get; set; }
        
        public string? NumeroDocumentoExterno { get; set; }

        public string? Mensagem { get; set; }
    }
}
