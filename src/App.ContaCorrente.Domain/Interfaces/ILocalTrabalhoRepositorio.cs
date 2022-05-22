using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ILocalTrabalhoRepositorio : IDisposable
    {
        Task<LocalTrabalho> GetPeloIdAsync(int? id);
        
        Task<LocalTrabalho> AlterarAsync(LocalTrabalho localTrabalho);
        
        Task<LocalTrabalho> CriarAsync(LocalTrabalho localTrabalho);
        
    }
}
