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
        Task<Historico> GetPeloIdAsync(int? id);

        Task<Historico> AlterarAsync(Endereco endereco);

        Task<Historico> CriarAsync(Endereco endereco);


    }
}
