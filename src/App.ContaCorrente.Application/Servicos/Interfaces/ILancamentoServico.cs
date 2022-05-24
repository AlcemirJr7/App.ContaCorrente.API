using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ILancamentoServico
    {
        Task<LancamentoDTO> GetPeloIdAsync(int? id);

        Task<IEnumerable<LancamentoDTO>> GetPeloCorrentistaIdAsync(int? id);

        Task<Lancamento> CriarAsync(LancamentoDTO lancamentoDto);
    }
}
