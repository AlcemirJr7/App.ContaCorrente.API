using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IParcelasEmprestimoRepositorio : IDisposable
    {
        Task<IEnumerable<ParcelasEmprestimo>> GetPeloIdAsync(int? id);

        Task<IEnumerable<ParcelasEmprestimo>> GetPeloEmprestimoIdAsync(int? id);

        Task<ParcelasEmprestimo> AlterarAsync(ParcelasEmprestimo parcelasEmprestimo);

        Task<IEnumerable<ParcelasEmprestimo>> CriarAsync(IEnumerable<ParcelasEmprestimo> parcelasEmprestimo);


    }
}
