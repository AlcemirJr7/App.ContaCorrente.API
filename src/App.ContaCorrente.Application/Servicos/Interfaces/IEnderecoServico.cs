using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;


namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IEnderecoServico
    {
        Task<EnderecoDTO> GetPeloIdAsync(int? id);

        Task<Endereco> AlterarAsync(EnderecoDTO enderecoDto);

        Task<Endereco> CriarAsync(EnderecoDTO enderecoDto);

        Task<Endereco> DeletarAsync(int? id);
    }
}
