using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ITransferenciaServico
    {
        Task<TransferenciaInternaPixDTO> GetPeloIdAsync(int? id);

        Task<TransferenciaInternaPixDTO> AlterarAsync(TransferenciaInternaPixDTO transferenciaDto);

        Task<TransferenciaInternaPixDTO> CriarPixAsync(TransferenciaInternaPixDTO transferenciaDto);
    }
}
