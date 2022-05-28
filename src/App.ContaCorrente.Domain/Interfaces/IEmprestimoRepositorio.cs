using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IEmprestimoRepositorio 
    {
        Task<Emprestimo> GetPeloIdAsync(int? id);

        Task<IEnumerable<Emprestimo>> GetPeloCorrentistaIdAsync(int? id);

        Task<Emprestimo> AlterarAsync(Emprestimo emprestimo);

        Task<Emprestimo> CriarAsync(Emprestimo emprestimo);

        Task<IEnumerable<Emprestimo>> GetEmprestimosEfetivadosPeloCorrentistaIdAsync(int? id);

        Task<IEnumerable<Emprestimo>> GetEmprestimosEfetivadosEmAbertoAsync();
    }
}
