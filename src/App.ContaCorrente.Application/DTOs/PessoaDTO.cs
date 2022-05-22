using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class PessoaDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? NomeEmpresa { get; set; }

        public long NumeroDocumento { get; set; }

        public EnumPessoa TipoPessoa { get;  set; }

        public long NumeroTelefone1 { get; set; }

        public long? NumeroTelefone2 { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public int EnderecoId { get; set; }        
        
    }
}
