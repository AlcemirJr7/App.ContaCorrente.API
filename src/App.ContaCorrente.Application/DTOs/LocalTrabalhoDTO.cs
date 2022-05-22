
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class LocalTrabalhoDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string NomeEmpresa { get; set; }

        public long NumeroDocumento { get; set; }

        public long NumeroTelefone1 { get; set; }

        public long? NumeroTelefone2 { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        public decimal Salario1 { get; set; }

        public decimal? Salario2 { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

    }
}
