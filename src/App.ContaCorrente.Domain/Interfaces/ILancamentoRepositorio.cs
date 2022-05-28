using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ILancamentoRepositorio 
    {
        Task<Lancamento> GetPeloIdAsync(int? id);

        Task<IEnumerable<Lancamento>> GetPeloCorrentistaIdAsync(int? id);        

        Task<Lancamento> CriarAsync(Lancamento lancamento);

        Task<Lancamento> DeletarAsync(int? id);

    }
}
