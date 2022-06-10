using App.ContaCorrente.Application.DTOs;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface ITransferenciaServico
    {
        Task<TransferenciaInternaPixDTO> GetPeloIdAsync(int? id);

        Task<TransferenciaInternaPixDTO> AlterarAsync(TransferenciaInternaPixDTO transferenciaDto);

        Task<TransferenciaInternaPixDTO> CriarPixInternoAsync(TransferenciaInternaPixDTO transferenciaDto);

        Task<TransferenciaInternaTedDTO> CriarTedInternoAsync(TransferenciaInternaTedDTO transferenciaDto);

        Task<TransferenciaExternaEnviaPixDTO> CriarPixExternoEnvioAsync(TransferenciaExternaEnviaPixDTO transferenciaDto);

        Task<TransferenciaExternaEnviaTedDTO> CriarTedExternoEnvioAsync(TransferenciaExternaEnviaTedDTO transferenciaDto);

        Task<TransferenciaInternaPixAgendaDTO> CriarPixInternoAgendamentoAsync(TransferenciaInternaPixAgendaDTO transferenciaDto);
    }
}
