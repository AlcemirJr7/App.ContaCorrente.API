using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IPagamentoServico
    {
        Task<PagamentoDTO> GetPeloIdAsync(int? id);

        Task<IEnumerable<PagamentoDTO>> GetPeloCorrentistaIdAsync(int? id);        

        Task<PagamentoDTO> CriarAsync(PagamentoDTO pagamentoDto);

        Task<PagamentoAgendaDTO> CriarAgendamentoAsync(PagamentoAgendaDTO pagamentoDto);

    }
}
