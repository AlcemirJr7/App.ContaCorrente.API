using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class ParcelasEmprestimoAntecipaDTO
    {
        public ParcelasEmprestimoAntecipaDTO()
        {

        }

        [JsonIgnore]
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public int SeqParcelas { get; set; }
        
        [JsonIgnore]
        public DateTime DataVencimento { get; set; }
                
        public DateTime? DataPagamento { get; set; }

        public int EmprestimoId { get; set; }

        public string? mensagem { get; set; }  
        
    }
}
