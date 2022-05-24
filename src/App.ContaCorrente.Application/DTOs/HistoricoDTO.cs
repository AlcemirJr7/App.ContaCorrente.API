using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;


namespace App.ContaCorrente.Application.DTOs
{
    public class HistoricoDTO
    { 
        
        public int Id { get; set; }
        
        public string Descricao { get; set; }

        /// <summary>
        /// 1 - Débito
        /// 2 - Crédito
        /// </summary>        
        public EnumHistoricoDebitoCredito TipoDebitoCredito { get; set; }

        [JsonIgnore]        
        public DateTime DataCriacao { get; set; }
    }
}
