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
        Task<Lancamento> GetPeloIdAsync(int? id);

        Task<IEnumerable<Lancamento>> GetPeloCorrentistaIdAsync(int? id);

        Task<Lancamento> AlterarAsync(Lancamento lancamentos);

        Task<Lancamento> CriarAsync(Lancamento lancamentos);

    }
}
