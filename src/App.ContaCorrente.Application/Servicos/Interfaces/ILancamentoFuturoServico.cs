using App.ContaCorrente.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ILancamentoFuturoServico
    {
        Task<LancamentoFuturoDTO> GetPeloIdAsync(int? id);

        Task<IEnumerable<LancamentoFuturoDTO>> GetPeloCorrentistaIdAsync(int? id);

        Task<LancamentoFuturoDTO> AlterarAsync(LancamentoFuturoDTO lancamentoFuturoDto);

        Task<LancamentoFuturoDTO> CriarAsync(LancamentoFuturoDTO lancamentoFuturoDto);
    }
}
