using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IHistoricoServico
    {
        Task<IEnumerable<HistoricoDTO>> GetHistoricosAsync();

        Task<HistoricoDTO> GetPeloIdAsync(int? id);

        Task AlterarAsync(HistoricoDTO historico);

        Task CriarAsync(HistoricoDTO historico);
    }
}
