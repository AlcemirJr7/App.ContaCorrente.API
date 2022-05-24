using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IBancoServico
    {
        Task<IEnumerable<BancoDTO>> GetBancosAsync();

        Task<BancoDTO> GetBancoPeloIdAsync(int? id);

        Task<BancoDTO> CriarAsync(BancoDTO bancoDto);

        Task<BancoDTO> AlterarAsync(BancoDTO bancoDto);        

    }
}
