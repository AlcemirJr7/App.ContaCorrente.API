using App.ContaCorrente.Domain.Enumerador;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class PessoaDTO
    {        
        public int Id { get; set; }

        public string Nome { get; set; }

        public string? NomeEmpresa { get; set; }

        public string NumeroDocumento { get; set; }

        public EnumPessoa TipoPessoa { get;  set; }

        public string NumeroTelefone1 { get; set; }

        public string? NumeroTelefone2 { get; set; }

        public string Email1 { get; set; }

        public string? Email2 { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        public int EnderecoId { get; set; }        
        
    }
}
