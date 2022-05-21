using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IEmprestimoRepositorio : IDisposable
    {
        Task<Emprestimo> GetPeloIdAsync(int? id);

        Task<IEnumerable<Emprestimo>> GetPeloCorrentistaIdAsync(int? id);

        Task<Emprestimo> AlterarAsync(Emprestimo emprestimo);

        Task<Emprestimo> CriarAsync(Emprestimo emprestimo);
    }
}
