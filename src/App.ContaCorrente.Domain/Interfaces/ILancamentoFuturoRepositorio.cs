using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ILancamentoFuturoRepositorio : IDisposable
    {
        Task<LancamentoFuturo> GetPeloIdAsync(int? id);

        Task<IEnumerable<LancamentoFuturo>> GetPeloCorrentistaIdAsync(int? id);

        Task<LancamentoFuturo> AlterarAsync(LancamentoFuturo lancamentoFuturo);

        Task<LancamentoFuturo> CriarAsync(LancamentoFuturo lancamentoFuturo);

        Task<IEnumerable<LancamentoFuturo>> GetLancamentosPendentesAsync();

    }
}
