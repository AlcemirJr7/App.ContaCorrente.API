using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IPessoaServico
    {
        Task<PessoaDTO> GetPeloIdAsync(int? id);

        Task<Pessoa> AlterarAsync(PessoaDTO pessoaDto);


        Task<Pessoa> CriarAsync(PessoaDTO pessoaDto);
    }
}
