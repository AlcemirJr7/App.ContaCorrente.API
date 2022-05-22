using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ILocalTrabalhoServico
    {
        Task<LocalTrabalhoDTO> GetPeloIdAsync(int? id);

        Task<LocalTrabalho> AlterarAsync(LocalTrabalhoDTO localTrabalhoPessoaDto);

        Task<LocalTrabalho> CriarAsync(LocalTrabalhoDTO localTrabalhoPessoaDto);
        
    }
}
