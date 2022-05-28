using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ISaldoContaCorrenteRepositorio 
    {
        Task<SaldoContaCorrente> GetPeloIdAsync(int? id);

        Task<SaldoContaCorrente> GetPeloCorrentistaIdAsync(int? id);

        Task<SaldoContaCorrente> AlterarAsync(SaldoContaCorrente saldoContaCorrente);

        Task<SaldoContaCorrente> CriarAsync(SaldoContaCorrente saldoContaCorrente);

    }
}
