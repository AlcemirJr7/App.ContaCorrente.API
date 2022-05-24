using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ICorrentistaServico
    {
        Task<Correntista> GetPeloIdAsync(int? id);        

        Task<Correntista> CriarAsync(CorrentistaDTO correntistaDto);

        Task<CorrentistaAlteraDTO> AlterarAsync(CorrentistaAlteraDTO correntistaDto);
    }
}
