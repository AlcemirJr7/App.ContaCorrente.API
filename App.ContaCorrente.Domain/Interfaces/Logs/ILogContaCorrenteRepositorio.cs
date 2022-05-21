using App.ContaCorrente.Domain.Entidades.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces.Logs
{
    public interface ILogContaCorrenteRepositorio
    {
        Task<LogContaCorrente> GetPeloIdAsync(int? id);

        Task<LogContaCorrente> GetPeloCorrentistaIdAsync(int? id);

        Task<LogContaCorrente> CriarAsync(LogContaCorrente logContaCorrente);

        Task<LogContaCorrente> AlterarAsync(LogContaCorrente logContaCorrente);
    }
}
