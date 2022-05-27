using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;

namespace App.ContaCorrente.Worker.Models
{
    public class LancamentoFuturoModel : LancamentoFuturoDTO
    {
        private readonly ILancamentoFuturoServico _lancamentoFuturoServico;

        public LancamentoFuturoModel(ILancamentoFuturoServico lancamentoFuturoServico)
        {
            _lancamentoFuturoServico = lancamentoFuturoServico;
        }


    }
}
