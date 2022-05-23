using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class CorrentistaDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public string? Agencia { get; set; }

        [JsonIgnore]
        public string? Conta { get; set; }

        [JsonIgnore]
        public DateTime? DataInicio { get; set; }

        [JsonIgnore]
        public DateTime? DataEncerramento { get; set; }

        [JsonIgnore]
        public EnumContaCorrente FlagConta { get; set; }

        public int PessoaId { get; set; }        
        
        [JsonIgnore]
        public int BancoId { get; set; }
        
        public int? LocalTrabalhoId { get; set; }

    }
}
