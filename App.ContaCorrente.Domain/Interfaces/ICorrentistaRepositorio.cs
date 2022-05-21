using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ICorrentistaRepositorio : IDisposable
    {
        Task<Correntista> GetPeloIdAsync(int? id);

        Task<Correntista> GetPeloPessoaIdAsync(int? id);

        Task<Correntista> CriarAsync(Correntista correntista);

        Task<Correntista> AlterarAsync(Correntista correntista);    

    }
}
