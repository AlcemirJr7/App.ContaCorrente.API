using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IBancoRepositorio : IDisposable
    {
        Task<IEnumerable<Banco>> GetBancosAsync();

        Task<Banco> GetBancosPeloIdAsync(int id);

        Task<Banco> CriarAsync(Banco banco);

        Task<Banco> AlterarAsync(Banco banco);
       
    }
}
