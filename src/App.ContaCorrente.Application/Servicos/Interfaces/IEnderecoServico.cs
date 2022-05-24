using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;


namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IEnderecoServico
    {
        Task<EnderecoDTO> GetPeloIdAsync(int? id);

        Task<EnderecoDTO> AlterarAsync(EnderecoDTO enderecoDto);

        Task<EnderecoDTO> CriarAsync(EnderecoDTO enderecoDto);

        Task<EnderecoDTO> DeletarAsync(int? id);
    }
}
