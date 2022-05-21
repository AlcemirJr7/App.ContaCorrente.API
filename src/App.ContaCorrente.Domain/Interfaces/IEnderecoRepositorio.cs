using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IEnderecoRepositorio : IDisposable
    {
        Task<Endereco> GetPeloIdAsync(int? id);

        Task<Endereco> AlterarAsync(Endereco endereco);

        Task<Endereco> CriarAsync(Endereco endereco);

        Task<Endereco> DeletarAsync(Endereco endereco);

    }
}
