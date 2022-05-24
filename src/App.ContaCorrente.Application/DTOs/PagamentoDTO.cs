using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.DTOs
{
    public class PagamentoDTO
    {
        public int Id { get; set; }

        public string CodigoBarra { get; set; }

        public string NumeroDocumento { get; set; }

        public DateTime DataGeracao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public DateTime DataPagamento { get; set; }

        public int CorrentistaId { get; set; }
    }
}
