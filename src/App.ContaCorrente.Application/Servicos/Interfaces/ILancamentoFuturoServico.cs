using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ILancamentoFuturoServico
    {
        Task<LancamentoFuturoDTO> GetPeloIdAsync(int? id);

        Task<IEnumerable<LancamentoFuturoDTO>> GetPeloCorrentistaIdAsync(int? id);        

        Task<LancamentoFuturoDTO> CriarAsync(LancamentoFuturoDTO lancamentoFuturoDto);

        Task<IEnumerable<LancamentoFuturoDTO>> ProcessaLancamentosFuturos();

        Task AtualizaLancamentoFuturoPagamento(int? id);

        Task<LancamentoFuturoDTO> CancelarAsync(int? id);
    }
}
