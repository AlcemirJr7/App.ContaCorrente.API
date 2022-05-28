using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IParcelasEmprestimoRepositorio 
    {
        Task<ParcelasEmprestimo> GetSeqParcelaAsync(int? parcela, int? emprestimoId);

        Task<IEnumerable<ParcelasEmprestimo>> GetPeloEmprestimoIdAsync(int? id);

        Task<ParcelasEmprestimo> AlterarAsync(ParcelasEmprestimo parcelasEmprestimo);

        Task<IEnumerable<ParcelasEmprestimo>> CriarAsync(IEnumerable<ParcelasEmprestimo> parcelasEmprestimo);

        Task<IEnumerable<ParcelasEmprestimo>> GetParcelasAhVencerAsync(int? emprestimoId);


    }
}
