using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ILancamentoFuturoRepositorio : IDisposable
    {
        Task<LancamentoFuturo> GetPeloIdAsync(int? id);

        Task<IEnumerable<LancamentoFuturo>> GetPeloCorrentistaIdAsync(int? id);

        Task<LancamentoFuturo> AlterarAsync(LancamentoFuturo lancamentoFuturo);

        Task<LancamentoFuturo> CriarAsync(LancamentoFuturo lancamentoFuturo);

    }
}
