using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class PagamentoAgendaDTO
    {
        public PagamentoAgendaDTO()
        {

        }

        public int Id { get; set; }

        public string CodigoBarra { get; set; }

        public string NumeroDocumento { get; set; }

        public DateTime DataGeracao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }
        
        [JsonIgnore]
        public DateTime? DataPagamento { get; set; }

        public DateTime? DataAgendamento { get; set; }

        public int CorrentistaId { get; set; }
                
        public string? Mensagen { get; set; }
    }
}
