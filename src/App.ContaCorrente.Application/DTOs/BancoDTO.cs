using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class BancoDTO
    {
        [JsonPropertyName("codigo")]
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string NomeCompleto { get; set; }
    }
}
