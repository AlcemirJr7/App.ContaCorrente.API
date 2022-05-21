using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ILancamentosRepositorio : IDisposable
    {
        Task<Lancamentos> GetPeloIdAsync(int? id);

        Task<IEnumerable<Lancamentos>> GetPeloCorrentistaIdAsync(int? id);

        Task<Lancamentos> AlterarAsync(Lancamentos lancamentos);

        Task<Lancamentos> CriarAsync(Lancamentos lancamentos);

    }
}
