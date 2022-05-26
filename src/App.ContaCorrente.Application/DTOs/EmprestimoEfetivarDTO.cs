using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class EmprestimoEfetivarDTO
    {
        public EmprestimoEfetivarDTO()
        {

        }

        public int Id { get; set; }

        public decimal Valor { get; set; }

        public EnumEmprestimoTipoFinalidade TipoFinalidade { get; set; }

        public EnumEmprestimoTipoEmprestimo TipoEmprestimo { get; set; }

        public int QtdParcelas { get; set; }
        
        public decimal ValorParcela { get; set; }

        public decimal Juros { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }
        
        public DateTime? DataEfetivacao { get; set; }
        
        public EnumFlagEstadoEmprestimo FlagEstado { get; set; }
        
        public EnumProcessoEmprestimo FlagProcesso { get; set; }

        public int CorrentistaId { get; set; }

        public string? Mensagem { get; set; }

    }
}
