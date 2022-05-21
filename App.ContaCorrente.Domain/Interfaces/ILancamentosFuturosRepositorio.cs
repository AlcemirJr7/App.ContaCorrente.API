using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ILancamentosFuturosRepositorio : IDisposable
    {
        Task<LancamentosFuturos> GetPeloIdAsync(int? id);

        Task<IEnumerable<LancamentosFuturos>> GetPeloCorrentistaIdAsync(int? id);

        Task<LancamentosFuturos> AlterarAsync(LancamentosFuturos lancamentosFuturos);

        Task<LancamentosFuturos> CriarAsync(LancamentosFuturos lancamentosFuturos);

    }
}
