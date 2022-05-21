using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IPessoaRepositorio : IDisposable
    {
        Task<Pessoa> GetPeloIdAsync(int? id);

        Task<Pessoa> AlterarAsync(Pessoa pessoa);

        Task<Pessoa> CriarAsync(Pessoa pessoa);
    }
}
