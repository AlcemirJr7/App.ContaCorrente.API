using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ITransferenciaRepositorio : IDisposable
    {
        Task<Transferencia> GetPeloIdAsync(int? id);

        Task<Transferencia> AlterarAsync(Transferencia transferencia);

        Task<Transferencia> CriarAsync(Transferencia transferencia);

    }
}
