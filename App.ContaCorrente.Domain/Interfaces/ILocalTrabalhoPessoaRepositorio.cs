using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ILocalTrabalhoPessoaRepositorio : IDisposable
    {
        Task<LocalTrabalhoPessoa> GetPeloIdAsync(int? id);
        
        Task<LocalTrabalhoPessoa> AlterarAsync(LocalTrabalhoPessoa localTrabalhoPessoa);
        
        Task<LocalTrabalhoPessoa> CriarAsync(LocalTrabalhoPessoa localTrabalhoPessoa);

        Task<LocalTrabalhoPessoa> DeletarAsync(int? id);
    }
}
