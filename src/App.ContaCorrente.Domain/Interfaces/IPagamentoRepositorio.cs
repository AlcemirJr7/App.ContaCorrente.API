using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IPagamentoRepositorio 
    {
        Task<Pagamento> GetPeloIdAsync(int? id);

        Task<IEnumerable<Pagamento>> GetPeloCorrentistaIdAsync(int? id);        

        Task<Pagamento> CriarAsync(Pagamento pagamento);

        Task<Pagamento> DeletarAsync(int? id);

        Task<Pagamento> AtualizarAsync(Pagamento pagamento);

    }
}
