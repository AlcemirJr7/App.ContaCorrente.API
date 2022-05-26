using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class ParcelasEmprestimoDTO
    {
        public ParcelasEmprestimoDTO()
        {

        }

        [JsonIgnore]
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public int SeqParcelas { get; set; }
       
        public DateTime DataVencimento { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; }

        public int EmprestimoId { get; set; }
        
    }
}
