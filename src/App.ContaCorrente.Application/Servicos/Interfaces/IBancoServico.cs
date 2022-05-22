using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;
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

        Task<Banco> CriarAsync(BancoDTO bancoDto);

        Task<Banco> AlterarAsync(BancoDTO bancoDto);        

    }
}
