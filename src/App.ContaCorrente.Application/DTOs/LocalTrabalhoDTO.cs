
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class LocalTrabalhoDTO
    {      
        public int Id { get; set; }

        public string NomeEmpresa { get; set; }

        public string NumeroDocumento { get; set; }

        public string NumeroTelefone1 { get; set; }

        public string? NumeroTelefone2 { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        public decimal Salario1 { get; set; }

        public decimal? Salario2 { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

    }
}
