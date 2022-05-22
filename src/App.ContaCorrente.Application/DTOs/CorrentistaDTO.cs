using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class CorrentistaDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int Agencia { get; set; }

        public long Conta { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime? DataEncerramento { get; set; }

        public EnumContaCorrente FlagConta { get; set; }

        public int PessoaId { get; set; }        

        public int BancoId { get; set; }
        
    }
}
