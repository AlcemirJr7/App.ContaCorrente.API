using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ILancamentoServico
    {
        Task<LancamentoDTO> GetPeloIdAsync(int? id);

        Task<IEnumerable<LancamentoDTO>> GetPeloCorrentistaIdAsync(int? id);

        Task<LancamentoDTO> CriarAsync(LancamentoDTO lancamentoDto);

        
    }
}
