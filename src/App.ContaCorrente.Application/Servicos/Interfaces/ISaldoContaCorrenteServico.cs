using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ISaldoContaCorrenteServico
    {
        Task<SaldoContaCorrenteDTO> GetPeloIdAsync(int? id);

        Task<SaldoContaCorrenteDTO> GetPeloCorrentistaIdAsync(int? id);

        Task ValidaSaldoAsync(int correntistaId, int historicoId, decimal valor);
        
        Task AtulizaSaldoAsync(int correntistaId, int historicoId, decimal valor);


    }
}
