using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IHistoricoRepositorio : IDisposable
    {
        Task<IEnumerable<Historico>> GetHistoricosAsync();

        Task<Historico> GetPeloIdAsync(int? id);

        Task<Historico> AlterarAsync(Historico historico);

        Task<Historico> CriarAsync(Historico historico);


    }
}
