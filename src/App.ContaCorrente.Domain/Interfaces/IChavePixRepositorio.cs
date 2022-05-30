using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Domain.Interfaces
{
    public interface IChavePixRepositorio
    {
       
        Task<ChavePix> GetChavePixPeloCorrentistaIdAsync(int? id);

        Task<ChavePix> GetChavePixPelaChaveAsync(string? chave);

        Task<ChavePix> CriarAsync(ChavePix chavePix);

        Task<ChavePix> AlterarAsync(ChavePix chavePix);

        Task<ChavePix> GetChavePixAtivaPeloCorrentistaIdAsync(int? id);
    }
}
