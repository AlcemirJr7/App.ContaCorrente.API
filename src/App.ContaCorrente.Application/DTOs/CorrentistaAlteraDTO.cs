using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;


namespace App.ContaCorrente.Application.DTOs
{
    public class CorrentistaAlteraDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public string? Agencia { get; set; }

        [JsonIgnore]
        public string? Conta { get; set; }
        
        public DateTime? DataInicio { get; set; }
        
        public DateTime? DataEncerramento { get; set; }
        
        public EnumContaCorrente FlagConta { get; set; }
        
        [JsonIgnore]
        public int PessoaId { get; set; }

        [JsonIgnore]
        public int BancoId { get; set; }

        public int? LocalTrabalhoId { get; set; }
    }
}
