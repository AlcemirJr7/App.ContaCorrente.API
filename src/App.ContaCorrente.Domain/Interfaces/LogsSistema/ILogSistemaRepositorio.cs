using App.ContaCorrente.Domain.Entidades.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces.Logs
{
    public interface ILogSistemaRepositorio : IDisposable
    {
        Task<LogSistema> GetPeloIdAsync(int? id);

        Task<LogSistema> CriarAsync(LogSistema logSistema);

        Task<LogSistema> AlterarAsync(LogSistema logSistema);
    }
}
