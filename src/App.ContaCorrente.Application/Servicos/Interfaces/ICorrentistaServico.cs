using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ICorrentistaServico
    {
        Task<Correntista> GetPeloIdAsync(int? id);        

        Task<Correntista> CriarAsync(CorrentistaDTO correntistaDto);

        Task<Correntista> AlterarAsync(CorrentistaAlteraDTO correntistaDto);
    }
}
