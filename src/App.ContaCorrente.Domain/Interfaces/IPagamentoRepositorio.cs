using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IPagamentoRepositorio : IDisposable
    {
        Task<Pagamento> GetPeloIdAsync(int? id);

        Task<IEnumerable<Pagamento>> GetPeloCorrentistaIdAsync(int? id);        

        Task<Pagamento> CriarAsync(Pagamento pagamento);

        Task<Pagamento> DeletarAsync(int? id);

    }
}
