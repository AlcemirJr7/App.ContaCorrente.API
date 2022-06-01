using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface ICorrentistaRepositorio 
    {
        Task<Correntista> GetPeloIdAsync(int? id);

        Task<Correntista> GetPelaContaAgenciaBancoAsync(int? banco, string? agencia, string? conta);

        Task<Correntista> CriarAsync(Correntista correntista);

        Task<Correntista> AlterarAsync(Correntista correntista);    

    }
}
