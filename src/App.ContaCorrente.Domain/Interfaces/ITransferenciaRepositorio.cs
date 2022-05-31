using App.ContaCorrente.Domain.Entidades.Transferencia;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ITransferenciaRepositorio 
    {
        Task<Transferencia> GetPeloIdAsync(int? id);

        Task<Transferencia> AlterarAsync(Transferencia transferencia);

        Task<Transferencia> CriarAsync(Transferencia transferencia);

    }
}
