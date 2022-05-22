using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class BancoDTO
    {        
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public string NomeCompleto { get; set; }
    }
}
