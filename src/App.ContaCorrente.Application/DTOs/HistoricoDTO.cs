using App.ContaCorrente.Domain.Enumerador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.DTOs
{
    public class HistoricoDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatorio.")]
        public string Descricao { get; set; }

        /// <summary>
        /// 1 - Débito
        /// 2 - Crédito
        /// </summary>
        [Required(ErrorMessage = "Tipo debito credito é obrigatorio.")]
        public EnumHistoricoDebitoCredito TipoDebitoCredito { get; set; }

        [JsonIgnore]        
        public DateTime DataCriacao { get; set; }
    }
}
