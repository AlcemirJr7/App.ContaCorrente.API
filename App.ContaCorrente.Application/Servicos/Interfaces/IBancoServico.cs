using App.ContaCorrente.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IBancoServico
    {
        Task<IEnumerable<BancoDTO>> GetBancosAsync();

        Task<BancoDTO> GetBancoPeloIdAsync(int? id);

        Task CriarAsync(BancoDTO bancoDto);

        Task AlterarAsync(BancoDTO bancoDto);        

    }
}
