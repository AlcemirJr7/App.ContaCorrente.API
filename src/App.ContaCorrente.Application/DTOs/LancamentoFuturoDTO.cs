using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class LancamentoFuturoDTO
    {
        public LancamentoFuturoDTO()
        {

        }

        public int Id { get;  set; }

        public decimal Valor { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        public DateTime DataParaLancamento { get; set; }

        public EnumTipoLancamentoFuturo TipoLancamento { get; set; }

        [JsonIgnore]
        public EnumLancamentoFuturo FlagLancamento { get; set; }

        public string? Observacao { get; set; }

        public EnumSituacaoLancamentoFuturo Situacao { get; set; }

        [JsonIgnore]
        public DateTime? DataLancamento { get; set; }

        public int HistoricoId { get; set; }
        
        public int CorrentistaId { get; set; }

        
    }
}
