using App.ContaCorrente.Domain.Enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.DTOs
{
    public class EmprestimoDTO
    {
        public EmprestimoDTO()
        {

        }

        public int Id { get; set; }

        public decimal Valor { get; set; }

        public EnumEmprestimoTipoFinalidade TipoFinalidade { get; set; }

        public EnumEmprestimoTipoEmprestimo TipoEmprestimo { get; set; }

        public int QtdParcelas { get; set; }

        [JsonIgnore]
        public decimal ValorParcela { get; set; }

        public decimal Juros { get; set; }

        [JsonIgnore]
        public DateTime DataCadastro { get; set; }

        [JsonIgnore]
        public DateTime? DataEfetivacao { get; set; }

        [JsonIgnore]
        public EnumFlagEstadoEmprestimo FlagEstado { get; set; }

        [JsonIgnore]
        public EnumProcessoEmprestimo FlagProcesso { get; set; }

        public int CorrentistaId { get; set; }
    }
}
