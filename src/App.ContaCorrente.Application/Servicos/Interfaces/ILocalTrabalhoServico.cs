using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ILocalTrabalhoServico
    {
        Task<LocalTrabalhoDTO> GetPeloIdAsync(int? id);

        Task AlterarAsync(LocalTrabalhoDTO localTrabalhoPessoaDto);

        Task CriarAsync(LocalTrabalhoDTO localTrabalhoPessoaDto);
        
    }
}
