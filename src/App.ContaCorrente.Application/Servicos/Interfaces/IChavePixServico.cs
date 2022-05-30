using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IChavePixServico
    {
        Task<ChavePixDTO> GetChavePixPeloCorrentistaIdAsync(int? id);

        Task<ChavePixDTO> GetChavePixPelaChaveAsync(string? chave);

        Task<ChavePixDTO> CriarAsync(ChavePixDTO chavePixDto);

        Task<ChavePixDTO> AlterarAsync(int? CorrentistaId);
    }
}
