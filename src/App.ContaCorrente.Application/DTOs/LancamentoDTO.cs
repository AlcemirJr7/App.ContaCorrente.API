﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.DTOs
{
    public class LancamentoDTO
    {
        public int Id { get; set; }

        public DateTime DataLancamento { get; set; }

        public decimal Valor { get; set; }

        public string? Observacao { get; set; }

        public int CorrentistaId { get; set; }
        
        public int HistoricoId { get; set; }

        
    }
}