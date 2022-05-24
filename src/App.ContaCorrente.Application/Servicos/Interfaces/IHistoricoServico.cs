using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IHistoricoServico
    {
        Task<IEnumerable<HistoricoDTO>> GetHistoricosAsync();

        Task<HistoricoDTO> GetPeloIdAsync(int? id);

        Task<HistoricoDTO> AlterarAsync(HistoricoDTO historico);

        Task<HistoricoDTO> CriarAsync(HistoricoDTO historico);
    }
}
